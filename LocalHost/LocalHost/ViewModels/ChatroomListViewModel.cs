using System;
using System.Diagnostics;
using LocalHost.Models;
using LocalHost.Views;
using Xamarin.Forms;

namespace LocalHost.ViewModels
{
<<<<<<< HEAD
    public class ChatroomListViewModel : ViewModelBase
=======
    public class ChatroomListViewModel : ViewModelBase, IObserverViewModel
>>>>>>> SignUp/SignIn-Page
    {
        IDataStore DataStore;
        public ChatroomList list { get; set; }
        public ListView chatroomListView;

        public ChatroomListViewModel(Page page) : base(page)
        {
            DataStore = App.dataStore;
<<<<<<< HEAD
            MessagingCenter.Subscribe<OfflineDataStore>(this, OfflineDataStore.LOAD_FINISHED, (sender) => { GetChatRoomsCommand().Execute(null); });
=======
            DataStore.Subscribe(this);
            getData();
>>>>>>> SignUp/SignIn-Page
        }

        //public void getChatrooms()
        //{
        //    ChatroomList list = DataStore.GetChatrooms().Result;
        //    this.list = list;
        //}

        public void addChatroom(string newChatroomTitle){
            Chatroom newChatroom = new Chatroom();
            newChatroom.Title = newChatroomTitle;

            //Fake - fix this
            newChatroom.AdminID = "";
            newChatroom.ID = "";
            newChatroom.Location = new string[] { "", "" };
            newChatroom.ParticipantIDs = new string[] { "" };
<<<<<<< HEAD
            Message initMessage = Chatroom.GetFirstMessage(newChatroomTitle);
=======
            Message initMessage = new Message();
            initMessage.LineText = ("Welcome to " + newChatroomTitle + "!");
            initMessage.MessageID = "";
            initMessage.SenderID = "";
            initMessage.SenderName = "LocalHost";
>>>>>>> SignUp/SignIn-Page
            newChatroom.ChatLog.Add("0000", initMessage);

            list.Add(newChatroom);
            DataStore.UpdateChatrooms(list);
            //getChatrooms();
            chatroomListView.ItemsSource = list;
        }

        public void deleteChatroom(Chatroom chatroom){
            list.Remove(chatroom);
            DataStore.UpdateChatrooms(list);
            //getChatrooms();
        }

<<<<<<< HEAD
        private Command GetChatRoomsCommand()
        {
            return new Command(async () => 
            { 
                try 
                {  
                    list = await DataStore.GetChatrooms(); 
                    chatroomListView.ItemsSource = list;
                } 
                catch (Exception ex) 
                { 
                    Debug.WriteLine("ChatroomList : " + ex.Message); 
                }
            });
=======
        public void getData()
        {
            ChatroomList list = DataStore.GetChatrooms().Result;
            this.list = list;
>>>>>>> SignUp/SignIn-Page
        }
    }
}
