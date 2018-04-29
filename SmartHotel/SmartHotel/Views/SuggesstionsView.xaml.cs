using SmartHotel.Helpers;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SuggesstionsView : ContentPage
    {
        public SuggesstionsView()
        {
            try
            {
                InitializeComponent();
                if (Device.RuntimePlatform != Device.iOS)
                {
                    NavigationPage.SetHasNavigationBar(this, false);
                }

                NavigationPage.SetBackButtonTitle(this, string.Empty);
                MapHelper.CenterMapInDefaultLocation(this.Map);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("CustomError_SuggesstionsView: " + ex.ToString());
            }

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            StatusBarHelper.Instance.MakeTranslucentStatusBar(false);
        }
    }
}