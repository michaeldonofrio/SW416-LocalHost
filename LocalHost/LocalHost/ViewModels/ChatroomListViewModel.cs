using System;
using System.Diagnostics;
using LocalHost.Models;
using LocalHost.Views;
using MvvmHelpers;
using Xamarin.Forms;

namespace LocalHost.ViewModels
{
    public class ChatroomListViewModel : ViewModelBase, IObserverViewModel
    {
        User user;
        IDataStore DataStore;
        public ChatroomList list;

        public ListView chatroomListView;

        public ChatroomListViewModel(ChatroomList list, Page page) : base(page)
        {
            list = new ChatroomList();
            this.list = list;
            DataStore = App.dataStore;
            DataStore.Subscribe(this);
            getData();
        }


        public void addChatroom(string newChatroomTitle){
            Chatroom newChatroom = new Chatroom(newChatroomTitle);
            this.list.Add(newChatroom);
            this.user.ChatroomIDs.Add(newChatroom.ID);
            DataStore.UpdateLocalChatrooms(list).Wait();
            DataStore.UpdateLocalUser(user).Wait();
            chatroomListView.ItemsSource = list;
        }

        public void deleteChatroom(Chatroom chatroom){
            list.Remove(chatroom);
            DataStore.UpdateLocalChatrooms(list);
        }

        public void getData()
        {
            user = DataStore.GetLocalUser().Result;
            ChatroomList list = DataStore.GetLocalChatrooms().Result;
            if (list != null)
            {
                this.list.ReplaceRange(list);
            }
        }
    }
}
