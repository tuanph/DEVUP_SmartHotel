using SmartHotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuView : ContentPage
    {
        public MenuView()
        {
            InitializeComponent();
            BindingContext = new MenuViewModel();
        }
        private void listViewMenuItem_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listViewMenuItem.SelectedItem == null)
                return;
            listViewMenuItem.SelectedItem = null;
        }
        private void OnBookingMenuTapped(object sender, EventArgs args)
        {
            this.NavigationToPage(new BookingView());
        }
        private void OnMyRoomMenuTapped(object sender, EventArgs args)
        {
            this.NavigationToPage(new MyRoomView());
        }
        private void OnSuggestionMenuTapped(object sender, EventArgs args)
        {
            this.NavigationToPage(new SuggesstionsView());
        }
        private void OnConciergeMenuTapped(object sender, EventArgs args)
        {
            this.NavigationToPage(new ConciergeView());
        }
        private void OnLogoutMenuTapped(object sender, EventArgs args)
        {
            App.Current.MainPage = new LoginView();
        }

        private void NavigationToPage(ContentPage page)
        {
            if (Application.Current.MainPage is MainView mainView)
            {
                if (mainView.Detail is NavigationPage navigationPage)
                {
                    navigationPage.PushAsync(page);
                    mainView.IsPresented = false;
                }
            }
        }
    }
}