using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
                        mainPage.Detail = navigationPage;
                    }

                    mainPage.IsPresented = false;
                }
                await ((ViewModelBase)viewModel).InitializeAsync(parameter);
            }
            catch (Exception ex)
            {

                throw;
            }


        }
    }
}
