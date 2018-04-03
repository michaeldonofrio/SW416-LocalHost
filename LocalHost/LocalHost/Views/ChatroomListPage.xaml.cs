using System;
using System.Collections.Generic;
using System.Diagnostics;
using LocalHost.Models;
using LocalHost.ViewModels;
using Xamarin.Forms;

namespace LocalHost.Views
{ 
    public partial class ChatroomListPage : ContentPage
    {
        ChatroomListViewModel viewModel;
        public ChatroomListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ChatroomListViewModel(null, this);

            ChatroomsListView.ItemsSource = viewModel.list;

            //Disables multi-select
            ChatroomsListView.ItemSelected += (sender, e) => {
                ((ListView)sender).SelectedItem = null;
            };

            //Open chatroom on tap
            ChatroomsListView.ItemTapped += (sender, e) =>
            {
                Navigation.PushAsync(new ChatroomPage(e.Item as Chatroom));
            };
        }
    }
}
