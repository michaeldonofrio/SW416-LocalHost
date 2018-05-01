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
        IDataStore DataStore;
        public ChatroomList list;
        public ListView chatroomListView;

        public ChatroomListViewModel(ChatroomList list, Page page) : base(page)
        {
            this.list = list;
            DataStore = App.dataStore;
            DataStore.Subscribe(this);
            getData();
        }


        public void addChatroom(string newChatroomTitle){
            Chatroom newChatroom = new Chatroom();
            newChatroom.Title = newChatroomTitle;

            //Fake - fix this
            newChatroom.AdminID = "";
            newChatroom.ID = "";
            newChatroom.Location = new string[] { "", "" };
            newChatroom.ParticipantIDs = new string[] { "" };
            Message initMessage = new Message();
            initMessage.LineText = ("Welcome to " + newChatroomTitle + "!");
            initMessage.MessageID = "";
            initMessage.SenderID = "";
            initMessage.SenderName = "LocalHost";
            newChatroom.ChatLog.Add("0000", initMessage);

            list.Add(newChatroom);
            DataStore.UpdateLocalChatrooms(list);
            //getChatrooms();
            chatroomListView.ItemsSource = list;
        }

        public void deleteChatroom(Chatroom chatroom){
            list.Remove(chatroom);
            DataStore.UpdateLocalChatrooms(list);
            //getChatrooms();
        }

        public void getData()
        {
            ChatroomList list = DataStore.GetLocalChatrooms().Result;
            this.list = list;
        }
    }
}
