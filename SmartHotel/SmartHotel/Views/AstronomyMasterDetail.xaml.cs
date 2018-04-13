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
    public partial class AstronomyMasterDetail : MasterDetailPage
    {
        public AstronomyMasterDetail()
        {
            InitializeComponent();
            this.Master = new AstronomyMasterPage();
            if (Device.RuntimePlatform == Device.iOS)
                master.Icon = (FileImageSource)ImageSource.FromFile("nav-menu-icon.png");
            this.Detail = new NavigationPage(new LoginView());
        }


    }
}