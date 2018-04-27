using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace LocalHost.Droid
{
    [Activity(Label = "SplashScreenActivity", 
              Theme ="@style/MyTheme.Splash", 
              MainLauncher = true, 
              NoHistory = true)]

    public class SplashScreenActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            StartActivity(typeof(MainActivity));
        }
    }
}