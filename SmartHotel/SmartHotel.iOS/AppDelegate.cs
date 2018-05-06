using System;
using System.Collections.Generic;
using System.Linq;
using CarouselView.FormsPlugin.iOS;
using FFImageLoading.Forms.Touch;
using Foundation;
using Microcharts.Forms;
using UIKit;

namespace SmartHotel.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            CachedImageRenderer.Init();
            CarouselViewRenderer.Init();
            Xamarin.FormsGoogleMaps.Init("api_key_here");
            InitChartView();
            InitXamanimation();
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            base.FinishedLaunching(app, options);

            //Custom app
            UINavigationBar.Appearance.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
            UINavigationBar.Appearance.ShadowImage = new UIImage();
            UINavigationBar.Appearance.BackgroundColor = UIColor.Clear;
            UINavigationBar.Appearance.TintColor = UIColor.White;
            UINavigationBar.Appearance.BarTintColor = UIColor.Clear;
            UINavigationBar.Appearance.Translucent = true;
            return true;
        }

        private static void InitChartView()
        {
            var t1 = typeof(ChartView);
        }

        private static void InitXamanimation()
        {
            var t2 = typeof(Xamanimation.AnimationBase);
        }
    }
}
