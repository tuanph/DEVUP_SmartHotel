using SmartHotel.ViewModels.Base;
using System.Threading.Tasks;

namespace SmartHotel.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        public override Task InitializeAsync(object navigationData)
        {
            return Task.WhenAll
                (
                    //_menuViewModel.InitializeAsync(navigationData),
                    NavigationService.NavigateToAsync<HomeViewModel>()
                );
        }
    }
}
