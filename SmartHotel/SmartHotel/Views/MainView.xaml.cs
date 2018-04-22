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
    public partial class MainView : MasterDetailPage
    {
        public MainView()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //if (Navigation.NavigationStack[0] is LoginView)
            //    Navigation.RemovePage(Navigation.NavigationStack[0]);//remove login View
        }
    }
}