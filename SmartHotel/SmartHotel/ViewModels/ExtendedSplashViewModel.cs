using SmartHotel.ViewModels.Base;
using System.Threading.Tasks;

namespace SmartHotel.ViewModels
{
    public class ExtendedSplashViewModel : ViewModelBase
    {
        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;

            await NavigationService.InitializeAsync((bool)navigationData);

            IsBusy = false;
        }
    }
}
