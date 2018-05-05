using Android.Content;
using Android.Widget;
using SmartHotel.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SmartHotel.Controls.BasicCalendar), typeof(SmartHotel.Droid.Renderers.BasicCalendarRenderer))]
namespace SmartHotel.Droid.Renderers
{
    public class BasicCalendarRenderer : ViewRenderer<BasicCalendar, CalendarView>
    {
        public BasicCalendarRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<BasicCalendar> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                SetNativeControl(new CalendarView(Context));
            }
        }

    }
}