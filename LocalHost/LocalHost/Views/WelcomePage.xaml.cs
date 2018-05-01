using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LocalHost.Views
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        public void goToLogIn(object sender, EventArgs e){
            Navigation.PushAsync(new LogInPage());
        }

        public void goToSignUp(object sender, EventArgs e){
            Navigation.PushAsync(new SignUpPage());
        }
    }
}
