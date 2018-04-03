using System;
using System.Diagnostics;
using LocalHost.Models;
using Xamarin.Forms;

namespace LocalHost.ViewModels
{
    public class ChatroomListViewModel : ViewModelBase
    {
        public ChatroomList list { get; set; }

        public ChatroomListViewModel(ChatroomList list, Page page) : base(page)
        {
            this.list = list;
            getChatrooms();
        }

        public void getChatrooms()
        {
            IDataStore fakeData = new MockDataStore();
            ChatroomList list = fakeData.GetChatrooms();
            this.list = list;
        }

    }
}
