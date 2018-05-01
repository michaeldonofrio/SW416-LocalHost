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

        public void SubmitSignUp(object sender, EventArgs e){
            if (viewModel.CreateUser(UsernameEntry.Text, PasswordEntry.Text, FirstNameEntry.Text, LastNameEntry.Text) == false){
                ErrorMessage.Text = "Username already in use. Please try again.";
                ErrorMessage.IsVisible = true;
            }else {
                Navigation.PopModalAsync();
            }
        }
    }
}
