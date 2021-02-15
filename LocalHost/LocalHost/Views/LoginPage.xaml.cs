using System;
using System.Collections.Generic;
using LocalHost.ViewModels;
using Xamarin.Forms;

namespace LocalHost.Views
{
    public partial class LogInPage : ContentPage
    {
        LogInViewModel viewModel;
        public LogInPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new LogInViewModel(this);
        }

        public void SubmitLogIn(object sender, EventArgs e)
        {
            if (viewModel.LogIn(UsernameEntry.Text, PasswordEntry.Text) == false)
            {
                ErrorMessage.Text = "Username or password invalid. Please try again.";
                ErrorMessage.IsVisible = true;
            }
            else
            {
                Navigation.PopModalAsync();
            }

        }
    }
}
