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
	public partial class MyRoomView : ContentPage
	{
		public MyRoomView ()
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
            //StatusBarHelper.Instance.MakeTranslucentStatusBar(false);
        }
    }
}