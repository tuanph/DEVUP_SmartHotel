using SmartHotel.Helpers;
using System;
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
            this.SizeChanged += OnSizeChanged;
            StatusBarHelper.Instance.MakeTranslucentStatusBar(false);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            this.SizeChanged -= OnSizeChanged;
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            AmbientLightSlider.WidthRequest = Width;
        }
    }
}