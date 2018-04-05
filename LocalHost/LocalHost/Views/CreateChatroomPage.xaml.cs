using System;
using System.Collections.Generic;
using System.Diagnostics;
using LocalHost.ViewModels;
using Xamarin.Forms;

namespace LocalHost.Views
{
    public partial class CreateChatroomPage : ContentPage
    {
        ChatroomListViewModel viewModel;
        public CreateChatroomPage(ChatroomListViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        public void createChatroom(object sender, EventArgs e){
            string newChatroomTitle = NewChatroomTitle.Text;
            viewModel.addChatroom(newChatroomTitle);
            Navigation.PopAsync();
        }
    }
}
