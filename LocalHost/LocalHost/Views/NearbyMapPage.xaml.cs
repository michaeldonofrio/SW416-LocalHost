using System;
using System.Collections.Generic;
using LocalHost.ViewModels;
using Xamarin.Forms;
using LocalHost.Models;
using Xamarin.Forms.Maps;
using System.Diagnostics;

namespace LocalHost.Views
{
    public partial class NearbyMapPage : ContentPage
    {
        NearbyMapViewModel viewModel;
        public NearbyMapPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new NearbyMapViewModel(this);
        }

        public void joinChatroom(object sender, EventArgs e)
        {
            switch (viewModel.joinChatroom())
            {
                case NearbyMapViewModel.joinChatroomResponse.SUCCESS:
                    {
                        DisplayAlert("Success!", "You have successfully joined " + viewModel.chatroomToJoin.Title, "Ok");
                        break;
                    }
                case NearbyMapViewModel.joinChatroomResponse.ERROR:
                    {
                        DisplayAlert("Uh-Oh!", "You have not selected a chatroom to join", "Ok");
                        break;
                    }
                case NearbyMapViewModel.joinChatroomResponse.DUPLICATE:
                    {
                        DisplayAlert("Whoops!", "You have alreayed joined " + viewModel.chatroomToJoin.Title, "Ok");
                        break;
                    }
            }
        }
    }
}