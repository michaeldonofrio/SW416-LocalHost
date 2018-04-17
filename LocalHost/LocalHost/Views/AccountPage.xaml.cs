using System;
using System.Collections.Generic;
using System.Diagnostics;
using LocalHost.Models;
using LocalHost.ViewModels;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace LocalHost.Views
{  
    public partial class AccountPage : ContentPage
    {
        AccountViewModel viewModel;
        public AccountPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AccountViewModel(this);
        }

        void updateUser (object sender, System.EventArgs e)
        {
            string updatedUsername = UsernameCell.Text;
            string updatedName = NameCell.Text;
            viewModel.updateUser(updatedUsername, updatedName);
        }
    }
}
