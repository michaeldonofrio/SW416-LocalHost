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

<<<<<<< HEAD
        public void SubmitSignUp(object sender, EventArgs e)
        {
=======
        public void SubmitSignUp(object sender, EventArgs e){
>>>>>>> SignUp/SignIn-Page
            viewModel.CreateUser(UsernameEntry.Text, FirstNameEntry.Text, LastNameEntry.Text);
            Navigation.PopModalAsync();
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> SignUp/SignIn-Page
