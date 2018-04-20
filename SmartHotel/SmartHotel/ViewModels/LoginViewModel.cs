using SmartHotel.Mvvm.Commands;
using SmartHotel.Services;
using SmartHotel.ViewModels.Base;
using System.ComponentModel;

namespace SmartHotel.ViewModels
{
    //Source
    public class LoginViewModel : ViewModelBase
    {
        private string _userName = string.Empty;
        private string _passWord = string.Empty;
        private string _passwordStrength = string.Empty;

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
        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand(Login, CanLogin)
                .ObservesProperty(() => UserName)
                .ObservesProperty(() => Password);
        }
        public DelegateCommand LoginCommand { get; }

        private void Login()
        {
            NavigationService.NavigateToAsync<MainViewModel>();
        }
        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(UserName)
                && !string.IsNullOrEmpty(Password);
        }
    }
}
