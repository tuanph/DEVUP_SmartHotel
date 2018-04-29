using SmartHotel.ViewModels.Base;
using System.Threading.Tasks;

namespace SmartHotel.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MenuViewModel MenuViewModel { get; set; }
        public MainViewModel()
        {
            MenuViewModel = new MenuViewModel();
        }
        public override Task InitializeAsync(object navigationData)
        {
            return Task.WhenAll
                (
                    MenuViewModel.InitializeAsync(navigationData),
                    NavigationService.NavigateToAsync<HomeViewModel>()
                );
        }
    }
}
