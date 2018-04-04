using System;
using System.Diagnostics;
using LocalHost.Models;
using LocalHost.Views;
using Xamarin.Forms;

namespace LocalHost.ViewModels
{
    public class ChatroomListViewModel : ViewModelBase
    {
        IDataStore DataStore;
        public ChatroomList list { get; set; }

        public ChatroomListViewModel(ChatroomList list, Page page) : base(page)
        {
            this.list = list;
            DataStore = App.dataStore;
            getChatrooms();
        }

        public void getChatrooms()
        {
            ChatroomList list = DataStore.GetChatrooms().Result;
            this.list = list;
        }

        public void addChatroom(){
            
        }

        public void deleteChatroom(Chatroom chatroom){
            list.Remove(chatroom);
            DataStore.UpdateChatrooms(list);
            getChatrooms();
        }
    }
}
