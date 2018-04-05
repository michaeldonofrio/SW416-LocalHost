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
        public ListView chatroomListView;

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
            newChatroom.ChatLog.Add("Poops", initMessage);

            list.Add(newChatroom);
            DataStore.UpdateChatrooms(list);
            getChatrooms();
            chatroomListView.ItemsSource = list;
        }

        public void deleteChatroom(Chatroom chatroom){
            list.Remove(chatroom);
            DataStore.UpdateChatrooms(list);
            getChatrooms();
        }
    }
}
