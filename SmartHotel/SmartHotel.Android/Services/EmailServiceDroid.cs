using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SmartHotel.Droid.Services;
using SmartHotel.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(EmailServiceDroid))]
namespace SmartHotel.Droid.Services
{
    public class EmailServiceDroid : IEmailService
    {
        public void Send(string email, string title, string content)
        {

        }
    }
}