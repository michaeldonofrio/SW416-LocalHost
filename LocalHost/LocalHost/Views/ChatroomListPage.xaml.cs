using System;
using System.Collections.Generic;
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
        }
    }
}
