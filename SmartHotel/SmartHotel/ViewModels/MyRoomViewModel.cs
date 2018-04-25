using SmartHotel.Mvvm.Commands;
using SmartHotel.ViewModels.Base;
using System;
using System.Threading.Tasks;

namespace SmartHotel.ViewModels
{
    public class MyRoomViewModel : ViewModelBase
    {
        private bool _ambient;
        private bool _need;
        private bool _find;
        private bool _noDisturb;
        private double _ambientLight;
        private double _temperature;
        private double _musicVolume;
        private double _windowBlinds;
        private bool _isEcoMode;

        public bool IsEcoMode
        {
            get => _isEcoMode;
            set => SetProperty(ref _isEcoMode, value);
        }
        public bool Ambient
        {
            get => _ambient;
            set => SetProperty(ref _ambient, value);
        }
        public bool Need
        {
            get => _need;
            set => SetProperty(ref _need, value);
        }
        public bool Find
        {
            get => _find;
            set => SetProperty(ref _find, value);
        }
        public bool NoDisturb
        {
            get => _noDisturb;
            set => SetProperty(ref _noDisturb, value);
        }
        public double AmbientLight
        {
            get => _ambientLight;
            set => SetProperty(ref _ambientLight, value);
        }
        public double Temperature
        {
            get => _temperature;
            set => SetProperty(ref _temperature, value);
        }
        public double MusicVolume
        {
            get => _musicVolume;
            set => SetProperty(ref _musicVolume, value);
        }
        public double WindowBlinds
        {
            get => _windowBlinds;
            set => SetProperty(ref _windowBlinds, value);
        }

        public DelegateCommand AmbientCommand => new DelegateCommand(SetAmbient);

        public DelegateCommand NeedCommand => new DelegateCommand(SetNeed);

        public DelegateCommand FindCommand => new DelegateCommand(SetFind);
        public DelegateCommand EcoModeCommand => new DelegateCommand(EcoMode);
        private void SetAmbient()
        {
            Ambient = true;
            Need = false;
            Find = false;
        }

        private void SetNeed()
        {
            Ambient = false;
            Need = true;
            Find = false;
        }

        private void SetFind()
        {
            Ambient = false;
            Need = false;
            Find = true;
        }
        private void EcoMode()
        {
            if (IsEcoMode)
                ActivateDefaultMode(true);
            else
                ActivateEcoMode(true);
        }
        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;
            SetAmbient();
            await Task.Delay(500);
            ActivateDefaultMode();

            IsBusy = false;
        }

        private void ActivateDefaultMode(bool showToast = false)
        {
            IsEcoMode = false;

            AmbientLight = 3400;
            Temperature = 70;
            MusicVolume = 45;
            WindowBlinds = 80;

            if (showToast)
            {
                DialogService.ShowToast("Turn off Eco Mode", 1000);
            }
        }

        private void ActivateEcoMode(bool showToast = false)
        {
            IsEcoMode = true;

            AmbientLight = 2400;
            Temperature = 60;
            MusicVolume = 40;
            WindowBlinds = 50;

            if (showToast)
            {
                DialogService.ShowToast("Eco mode active", 1000);
            }
        }
    }
}
