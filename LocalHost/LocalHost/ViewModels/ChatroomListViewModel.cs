using System;
using System.Diagnostics;
using System.Threading.Tasks;
using LocalHost.Models;
using LocalHost.Views;
using Xamarin.Forms;

namespace LocalHost.ViewModels
{
<<<<<<< HEAD
    public class ChatroomListViewModel : ViewModelBase, IObserverViewModel
=======
    public class ChatroomListViewModel : ViewModelBase, IDataStoreSubscriber
>>>>>>> PJK_Review
    {
        IDataStore DataStore;
        public ChatroomList list { get; set; }
        public ListView chatroomListView;

        public ChatroomListViewModel(ChatroomList list, Page page) : base(page)
        {
            this.list = list;
            DataStore = App.dataStore;
            DataStore.Subscribe(this);
<<<<<<< HEAD
            getData();
        }

        //public void getChatrooms()
        //{
        //    ChatroomList list = DataStore.GetChatrooms().Result;
        //    this.list = list;
        //}

        public void addChatroom(string newChatroomTitle){
=======
        }

        public void addChatroom(string newChatroomTitle)
        {
>>>>>>> PJK_Review
            Chatroom newChatroom = new Chatroom();
            newChatroom.Title = newChatroomTitle;

            //Fake - fix this
            newChatroom.AdminID = "";
            newChatroom.ID = "";
            newChatroom.Location = new string[] { "", "" };
            newChatroom.ParticipantIDs = new string[] { "" };
<<<<<<< HEAD
            Message initMessage = new Message();
            initMessage.LineText = ("Welcome to " + newChatroomTitle + "!");
            initMessage.MessageID = "";
            initMessage.SenderID = "";
            initMessage.SenderName = "LocalHost";
            newChatroom.ChatLog.Add("0000", initMessage);

            list.Add(newChatroom);
            DataStore.UpdateChatrooms(list);
            //getChatrooms();
=======
            Message initMessage = Chatroom.GetFirstMessage(newChatroomTitle);
            newChatroom.ChatLog.Add("Poops", initMessage);

            list.Add(newChatroom);
            DataStore.UpdateChatrooms(list);
>>>>>>> PJK_Review
            chatroomListView.ItemsSource = list;
        }

        public void deleteChatroom(Chatroom chatroom)
        {
            list.Remove(chatroom);
            DataStore.UpdateChatrooms(list);
<<<<<<< HEAD
            //getChatrooms();
        }

        public void getData()
        {
            ChatroomList list = DataStore.GetChatrooms().Result;
            this.list = list;
=======
            chatroomListView.ItemsSource = list;
        }

        private Command getChatRoomsCommand()
        {
            return new Command(async () => 
            { 
                try 
                {  
                    list = await DataStore.GetChatrooms(); 
                } 
                catch (Exception ex) 
                { 
                    Debug.WriteLine("ChatroomList : " + ex.Message); 
                }
            });
        }

        public async Task FinshedLoading(IDataStore dataStore)
        {
            list = await DataStore.GetChatrooms();
            chatroomListView.ItemsSource = list;
>>>>>>> PJK_Review
        }
    }
}
