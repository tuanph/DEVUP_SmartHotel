using SmartHotel.Models;
using SmartHotel.Mvvm.Commands;
using SmartHotel.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SmartHotel.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {

        private ObservableCollection<Notification> _notifications;
        public ObservableCollection<Notification> Notifications
        {
            get { return _notifications; }
            set => SetProperty(ref _notifications, value);

        }
        public HomeViewModel()
        {
            NotificationsCommand = new DelegateCommand(OnNotificationsAsync);
            OpenDoorCommand = new DelegateCommand(OpenDoor);
            Notifications = new ObservableCollection<Notification>
            {
                new Models.Notification { Text = "Cleaning services have finished refreshing your room.", Type = NotificationType.BeGreen },
                new Models.Notification { Text = "Your wave-up call reminder has been confirmed for 5:30 am.", Type = NotificationType.Room },
                new Models.Notification { Text = "Your conference room has been customized per your online request.", Type = NotificationType.Hotel },
                new Models.Notification { Text = "The SmartHotel360 bar and grill have a reservation set for 8:00 pm for 3 guests.", Type = NotificationType.Other }
            };
        }
        public DelegateCommand NotificationsCommand { get; }
        public DelegateCommand OpenDoorCommand { get; }

        private async void OpenDoor()
        {
            await NavigationService.NavigateToPopupAsync<OpenDoorViewModel>(true);
        }

        private void OnNotificationsAsync()
        {
            //return Task.CompletedTask;
            //return NavigationService.NavigateToAsync(typeof(NotificationsViewModel), Notifications);
        }
    }
}
