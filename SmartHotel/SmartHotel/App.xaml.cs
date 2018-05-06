using SmartHotel.Services.Navigation;
using SmartHotel.ViewModels;
using SmartHotel.ViewModels.Base;
using Xamarin.Forms;

namespace SmartHotel
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new NavigationPage(new SmartHotel.Views.LoginView());
            BuildDependencies();

        }
        public static void BuildDependencies()
        {
            Locator.Instance.Build();
            Locator.Instance.Reslove<INavigationService>().NavigateToAsync<LoginViewModel>();
            //Locator.Instance.Reslove<INavigationService>().NavigateToAsync<MainViewModel>();
            //Locator.Instance.Reslove<INavigationService>().NavigateToAsync<ExtendedSplashViewModel>(false);
        }
        protected override void OnStart()
        {
            // Handle when your app starts
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
