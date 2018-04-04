using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace LocalHost.Views
{
    public partial class CreateChatroomPage : ContentPage
    {
        public CreateChatroomPage()
        {
            InitializeComponent();
        }

        public void createChatroom(object sender, EventArgs e){
            
            Navigation.PopAsync();
        }
    }
}
