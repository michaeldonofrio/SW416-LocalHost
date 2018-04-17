using System;
using System.Collections.Generic;
using System.Diagnostics;
using LocalHost.Models;
using LocalHost.ViewModels;
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
            MessagingCenter.Subscribe<AccountViewModel>(this, AccountViewModel.UPDATE_NEEDED, (sender) => { GetUpdateCommand().Execute(null); });
        }

        public void Update()
        {
        }

        private Command GetUpdateCommand()
        {
            return new Command(() =>
            {
                try
                {
                    UsernameCell.Text = viewModel.Username;
                    NameCell.Text = viewModel.Name;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("ChatroomList : " + ex.Message);
                }
            });
        }

        void updateUser (object sender, System.EventArgs e)
        {
            string updatedUsername = UsernameCell.Text;
            string updatedName = NameCell.Text;
            viewModel.updateUser(updatedUsername, updatedName);
        }
    }
}
