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
                MapHelper.CenterMapInDefaultLocation(this.Map);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("CustomError_SuggesstionsView: " + ex.ToString());
            }

        }
    }
}