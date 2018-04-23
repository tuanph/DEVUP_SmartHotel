
using SmartHotel.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage() : base()
        {
            try
            {
                InitializeComponent();
            }
            catch (System.Exception ex)
            {

                throw;
            }

        }

        public CustomNavigationPage(Page root) : base(root)
        {
            try
            {
                InitializeComponent();
            }
            catch (System.Exception ex)
            {

                throw;
            }

        }
        internal void ApplyNavigationTextColor(Page targetPage)
        {
            try
            {
                var color = NavigationBarAttachedProperty.GetTextColor(targetPage);
                BarTextColor = color == Color.Default
                    ? Color.White
                    : color;
            }
            catch (System.Exception ex)
            {

                throw;
            }

        }
    }
}