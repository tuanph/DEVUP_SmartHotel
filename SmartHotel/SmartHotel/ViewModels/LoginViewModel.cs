using SmartHotel.Mvvm.Commands;
using SmartHotel.Services;
using SmartHotel.Services.Authentication;
using SmartHotel.Validations;
using SmartHotel.ViewModels.Base;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartHotel.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private ValidatableObject<string> _userName;
        private ValidatableObject<string> _password;
        private string _passwordStrength = string.Empty;
        private IAuthenticationService _IAuthenticationService;

        public ValidatableObject<string> UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value); // () => LoginCommand.RaiseCanExecuteChanged()

        }
        public ValidatableObject<string> Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        public LoginViewModel(IAuthenticationService IAuthenticationService)
        {
            _IAuthenticationService = IAuthenticationService;
            _userName = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();
            AddValidations();

            LoginCommand = new DelegateCommand(Login);

            //LoginCommand = new DelegateCommand(Login, CanLogin)
            //    .ObservesProperty(() => UserName)
            //    .ObservesProperty(() => Password);


        }

        private void AddValidations()
        {
            _userName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Username should not be empty" });
            _userName.Validations.Add(new EmailRule<string> { ValidationMessage = "Username should be an email address" });
            _password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password should not be empty" });
        }

        public DelegateCommand LoginCommand { get; }

        private async void Login()
        {
            bool isValid = Validate();
            if (!isValid)
                return;
            IsBusy = true;
            if (await _IAuthenticationService.LoginAsync(UserName.Value, Password.Value))
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
            //return !string.IsNullOrEmpty(UserName.Value)
            //    && !string.IsNullOrEmpty(Password.Value);
            return true;

        }

        private bool Validate()
        {
            bool isValidUser = _userName.Validate();
            bool isValidPassword = _password.Validate();

            return isValidUser && isValidPassword;
        }
    }
}
