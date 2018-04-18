using SmartHotel.Services;
using SmartHotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        private LoginViewModel LoginViewModel;
        public LoginView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            LoginViewModel = new LoginViewModel();
            this.BindingContext = LoginViewModel;
            var emailService = DependencyService.Get<IEmailService>();
            emailService.Send("tuancoi250689@gmail.com", "Test Email", "From Xamarin Forms");
        }
        public void Login_Click(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new MainView());
            //Navigation.PushModalAsync(); like a pop up, not go to view
            //PushAsync is not supported globally on Android, please use a NavigationPage
            //App.Current.MainPage = new MainView(); //way 1
        }

    }
}