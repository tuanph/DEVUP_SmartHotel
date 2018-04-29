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
            this.Map<NotificationsViewModel,NotificationsView>();
            this.Map<BookingViewModel, BookingView>();
            this.Map<ConciergeViewModel, ConciergeView>();
            this.Map<MyRoomViewModel, MyRoomView>();
            this.Map<SuggesstionsViewModel, SuggesstionsView>();
            this.Map<ExtendedSplashViewModel, ExtendedSplashView>();
        }

        private void Map<TViewModel, TView>()
            where TViewModel : ViewModelBase
            where TView : Page
        {
            this._mappings.Add(typeof(TViewModel), typeof(TView));
        }
    }
}
