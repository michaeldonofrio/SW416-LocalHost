using System;
using System.Collections.Generic;
using LocalHost.Models;
using LocalHost.ViewModels;
using Xamarin.Forms;

namespace LocalHost.Views
{ 
    public partial class ChatroomPage : ContentPage
    {
        ChatroomViewModel viewModel;
        public ChatroomPage(Chatroom chatroom)
        {
            InitializeComponent();
            BindingContext = viewModel = new ChatroomViewModel(chatroom, this);
            ChatLogListView.ItemsSource = viewModel.ChatLog.Values;
        }
    }
}
