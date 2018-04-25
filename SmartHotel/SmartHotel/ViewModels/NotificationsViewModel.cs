using SmartHotel.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartHotel.ViewModels
{
    public class NotificationsViewModel : ViewModelBase
    {

        private ObservableCollection<Models.Notification> _notifications;
        private bool _hasItems;


        public ObservableCollection<Models.Notification> Notifications
        {
            get => _notifications;
            set => SetProperty(ref _notifications, value);
        }

        public bool HasItems
        {
            get { return _hasItems; }
            set
            {
                _hasItems = value;
                OnPropertyChanged();
            }
        }

        public ICommand DeleteNotificationCommand => new Command<Models.Notification>(OnDelete);

        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData != null)
            {
                Notifications = (ObservableCollection<Models.Notification>)navigationData;
                HasItems = Notifications.Count > 0;
            }

            return base.InitializeAsync(navigationData);
        }

        private async void OnDelete(Models.Notification notification)
        {
            await Task.FromResult(0);
            //if (notification != null)
            //{
            //    Notifications.Remove(notification);
            //    await _notificationService.DeleteNotificationAsync(notification);
            //    HasItems = Notifications.Count > 0;
            //}
        }
    }
}
