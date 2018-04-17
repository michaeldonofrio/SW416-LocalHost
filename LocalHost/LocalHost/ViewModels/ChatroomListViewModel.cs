using System;
using System.Diagnostics;
using System.Threading.Tasks;
using LocalHost.Models;
using LocalHost.Views;
using Xamarin.Forms;

namespace LocalHost.ViewModels
{
    public class ChatroomListViewModel : ViewModelBase, IDataStoreSubscriber
    {
        IDataStore DataStore;
        public ChatroomList list { get; set; }
        public ListView chatroomListView;

        public ChatroomListViewModel(ChatroomList list, Page page) : base(page)
        {
            this.list = list;
            DataStore = App.dataStore;
            DataStore.Subscribe(this);
        }

        public void addChatroom(string newChatroomTitle)
        {
            Chatroom newChatroom = new Chatroom();
            newChatroom.Title = newChatroomTitle;

            //Fake - fix this
            newChatroom.AdminID = "";
            newChatroom.ID = "";
            newChatroom.Location = new string[] { "", "" };
            newChatroom.ParticipantIDs = new string[] { "" };
            Message initMessage = Chatroom.GetFirstMessage(newChatroomTitle);
            newChatroom.ChatLog.Add("Poops", initMessage);

            list.Add(newChatroom);
            DataStore.UpdateChatrooms(list);
            chatroomListView.ItemsSource = list;
        }

        public void deleteChatroom(Chatroom chatroom)
        {
            list.Remove(chatroom);
            DataStore.UpdateChatrooms(list);
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
        }
    }
}
