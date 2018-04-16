using System.ComponentModel;

namespace SmartHotel.ViewModels
{
    //Source
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _userName = string.Empty;
        private string _passWord = string.Empty;
        private string _passwordStrength = string.Empty;

        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName == value)
                    return;
                _userName = value;
                RasePropertyChanged(nameof(UserName));
            }
        }
        public string PasswordStrength
        {
            get => _passwordStrength;
            set
            {
                if (_passwordStrength == value)
                    return;
                _passwordStrength = value;
                RasePropertyChanged(nameof(PasswordStrength));
            }
        }
        public string Password
        {
            get { return _passWord; }
            set
            {
                if (_passWord == value)
                    return;
                _passWord = value;
                RasePropertyChanged(nameof(Password));
                if (_passWord != null && _passWord.Length > 6)
                    PasswordStrength = "Good";
                else
                    PasswordStrength = "Invald";

            }
        }

        private void RasePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
