using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookingView : ContentPage
	{
		public BookingView ()
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
	}
}