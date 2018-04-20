using SmartHotel.ViewModels;
using SmartHotel.ViewModels.Base;
using SmartHotel.Views;
using Xamarin.Forms;

namespace SmartHotel.Services.Navigation
{
    public partial class NavigationService
    {
        private void CreatePageViewModelMappings()
        {
            this.Map<LoginViewModel, LoginView>();
            this.Map<MainViewModel, MainView>();
            this.Map<HomeViewModel, HomeView>();
        }

        private void Map<TViewModel, TView>()
            where TViewModel : ViewModelBase
            where TView : Page
        {
            this._mappings.Add(typeof(TViewModel), typeof(TView));
            //Should be set Binding context here ????
        }
    }
}
