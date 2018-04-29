using SmartHotel.Mvvm.Commands;
using SmartHotel.Services;
using SmartHotel.Services.Authentication;
using SmartHotel.ViewModels.Base;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartHotel.ViewModels
{
    //Source
    public class LoginViewModel : ViewModelBase
    {
        private string _userName = string.Empty;
        private string _passWord = string.Empty;
        private string _passwordStrength = string.Empty;
        private IAuthenticationService _IAuthenticationService;

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value); // () => LoginCommand.RaiseCanExecuteChanged()

        }
        public string Password
        {
            get => _passWord;
            set => SetProperty(ref _passWord, value);
        }
        public LoginViewModel(IAuthenticationService IAuthenticationService)
        {
            _IAuthenticationService = IAuthenticationService;
            LoginCommand = new DelegateCommand(Login, CanLogin)
                .ObservesProperty(() => UserName)
                .ObservesProperty(() => Password);
        }
        public DelegateCommand LoginCommand { get; }
        //public ICommand LoginCommand => new Command(Login);
        private async void Login()
        {
            IsBusy = true;
            if (await _IAuthenticationService.LoginAsync(UserName, Password))
            {
                await NavigationService.NavigateToAsync<MainViewModel>();
            }
            else
            {
                await DialogService.ShowAlertAsync("Username or password invald.", "Information", "Ok");
            }
            IsBusy = false;
            //NavigationService.NavigateToAsync<HomeViewModel>();
        }
        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(UserName)
                && !string.IsNullOrEmpty(Password);
        }
    }
}
