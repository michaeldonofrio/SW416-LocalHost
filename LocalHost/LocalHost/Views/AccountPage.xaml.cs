using System;
using System.Collections.Generic;
using LocalHost.Models;
using LocalHost.ViewModels;
using Xamarin.Forms;

namespace LocalHost.Views
{
    public partial class AccountPage : ContentPage
    {
        AccountViewModel viewModel;
        public AccountPage(){
            InitializeComponent();
            BindingContext = viewModel = new AccountViewModel(null, this);
        }

    }
}
