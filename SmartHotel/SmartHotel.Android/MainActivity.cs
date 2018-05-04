using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Acr.UserDialogs;
using FFImageLoading.Forms.Droid;
using CarouselView.FormsPlugin.Android;
using Xamarin.Forms;
using SmartHotel.Helpers;
using Android.Util;

namespace SmartHotel.Droid
{
    [Activity(Label = "SmartHotel",
        Icon = "@drawable/icon",
        Theme = "@style/MainTheme",
        MainLauncher = false,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            //Rg.Plugins.Popup.Popup.Init(this, bundle);
            UserDialogs.Init(this);
            CachedImageRenderer.Init(false); // set false to fix issue height wrong
            Xamarin.FormsGoogleMaps.Init(this, bundle);
            CarouselViewRenderer.Init();
            global::Xamarin.Forms.Forms.Init(this, bundle);
            InitMessageCenterSubscriptions();
            LoadApplication(new App());
            MakeStatusBarTranslucent(false);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void InitMessageCenterSubscriptions()
        {
            MessagingCenter.Instance.Subscribe<StatusBarHelper, bool>(this, StatusBarHelper.TranslucentStatusChangeMessage, OnTranslucentStatusRequest);
        }

        private void OnTranslucentStatusRequest(StatusBarHelper helper, bool makeTranslucent)
        {
            MakeStatusBarTranslucent(makeTranslucent);
        }

        private void MakeStatusBarTranslucent(bool makeTranslucent)
        {
            if (makeTranslucent)
            {
                SetStatusBarColor(Android.Graphics.Color.Transparent);

                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                {
                    Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(SystemUiFlags.LayoutFullscreen | SystemUiFlags.LayoutStable);
                }
            }
            else
            {
                using (var value = new TypedValue())
                {
                    if (Theme.ResolveAttribute(Resource.Attribute.colorPrimaryDark, value, true))
                    {
                        var color = new Android.Graphics.Color(value.Data);
                        SetStatusBarColor(color);
                    }
                }

                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                {
                    Window.DecorView.SystemUiVisibility = StatusBarVisibility.Visible;
                }
            }
        }
    }
}

