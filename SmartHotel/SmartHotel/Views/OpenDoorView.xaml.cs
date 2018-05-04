using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace SmartHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OpenDoorView : PopupPage
    {
		public OpenDoorView ()
		{
			InitializeComponent ();
		}
        protected override bool OnBackgroundClicked()
        {
            return false;
        }
    }
}