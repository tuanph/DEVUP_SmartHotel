using Rg.Plugins.Popup.Services;
using SmartHotel.Mvvm.Commands;
using SmartHotel.ViewModels.Base;

namespace SmartHotel.ViewModels
{
    public class OpenDoorViewModel : ViewModelBase
    {
        public OpenDoorViewModel()
        {

        }

        public DelegateCommand ClosePopupCommand => new DelegateCommand(ClosePopupAsync);
        private async void ClosePopupAsync()
        {
            await PopupNavigation.PopAllAsync(true);
        }
    }
}
