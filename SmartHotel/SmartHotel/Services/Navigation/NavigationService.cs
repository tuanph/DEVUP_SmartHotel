using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AppCenter.Crashes;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SmartHotel.ViewModels;
using SmartHotel.ViewModels.Base;
using SmartHotel.Views;
using Xamarin.Forms;

namespace SmartHotel.Services.Navigation
{
    public partial class NavigationService : INavigationService
    {
        protected readonly Dictionary<Type, Type> _mappings;
        public NavigationService()
        {
            _mappings = new Dictionary<Type, Type>();
            //Map viewModel to View
            this.CreatePageViewModelMappings();
        }
        public async Task InitializeAsync(bool isLogin)
        {
            if (isLogin)
            {
                await NavigateToAsync<MainViewModel>();
            }
            else
            {
                await NavigateToAsync<LoginViewModel>();
            }
        }
        public Task NavigateBackAsync()
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            return NavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            return NavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            return NavigateToAsync(viewModelType, null);
        }

        public async Task NavigateToAsync(Type viewModelType, object parameter)
        {
            try
            {
                var pageType = _mappings[viewModelType];
                var page = (Page)Activator.CreateInstance(pageType);//create object at run time
                var viewModel = page.BindingContext = Locator.Instance.Resolve(viewModelType);// Link View to ViewModel
                if (page is LoginView)
                {
                    App.Current.MainPage = new NavigationPage(page);
                }
                else if (page is MainView)
                {
                    App.Current.MainPage = page;
                }
                else if (App.Current.MainPage is MainView)
                {
                    var mainPage = App.Current.MainPage as MainView;
                    var navigationPage = mainPage.Detail as CustomNavigationPage;

                    if (navigationPage != null)
                    {
                        var currentPage = navigationPage.CurrentPage;

                        if (currentPage.GetType() != page.GetType())
                        {
                            await navigationPage.PushAsync(page);
                        }
                    }
                    else
                    {
                        navigationPage = new CustomNavigationPage(page);
                        mainPage.Detail = navigationPage; // just set detail page, because Master page is Menu Page
                    }

                    mainPage.IsPresented = false;
                }
                else
                {
                    var navigationPage = App.Current.MainPage as CustomNavigationPage;

                    if (navigationPage != null)
                    {
                        await navigationPage.PushAsync(page);
                    }
                    else
                    {
                        App.Current.MainPage = new CustomNavigationPage(page);
                    }
                }
                await ((ViewModelBase)viewModel).InitializeAsync(parameter);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }


        }


        //Navigate by show pop up
        public Task NavigateToPopupAsync<TViewModel>(bool animate) where TViewModel : ViewModelBase
        {
            return NavigateToPopupAsync<TViewModel>(null, animate);
        }

        public async Task NavigateToPopupAsync<TViewModel>(object parameter, bool animate) where TViewModel : ViewModelBase
        {
            var pageType = _mappings[typeof(TViewModel)];
            var page = (Page)Activator.CreateInstance(pageType);//create object at run time
            var viewModel = page.BindingContext = Locator.Instance.Resolve(typeof(TViewModel));
            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);

            if (page is PopupPage)
            {
                await PopupNavigation.PushAsync(page as PopupPage, animate);
            }
            else
            {
                throw new ArgumentException($"The type ${typeof(TViewModel)} its not a PopupPage type");
            }
        }
    }
}
