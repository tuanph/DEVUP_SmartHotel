using SmartHotel.Services.Navigation;
using SmartHotel.ViewModels;
using SmartHotel.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SmartHotel
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SmartHotel.Views.LoginView());
           
        }
        public static void BuildDependencies()
        {
            Locator.Instance.Build();
            Locator.Instance.Reslove<INavigationService>().NavigateToAsync<LoginViewModel>();
        }
        protected override void OnStart()
        {
            // Handle when your app starts
            BuildDependencies();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
