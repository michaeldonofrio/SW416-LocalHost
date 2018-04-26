using System;
using System.Collections.Generic;
using System.Diagnostics;
using LocalHost.ViewModels;
using Xamarin.Forms;

namespace LocalHost.Views
{
    public partial class SignUpPage : ContentPage
    {
        SignUpViewModel viewModel;
        public SignUpPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new SignUpViewModel(this);
        }

        public void SubmitSignUp(object sender, EventArgs e)
        {
            viewModel.CreateUser(UsernameEntry.Text, FirstNameEntry.Text, LastNameEntry.Text);
            Navigation.PopModalAsync();
        }
    }
}