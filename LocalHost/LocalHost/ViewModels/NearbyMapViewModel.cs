using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using LocalHost.Models;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace LocalHost.ViewModels
{
    public class NearbyMapViewModel : ViewModelBase
    {
        private Position _myPosition = new Position(-37.8141, 144.9633);
        public Position MyPosition { get { return _myPosition; } set { _myPosition = value; OnPropertyChanged(); } }

        private ObservableCollection<Pin> _pinCollection = new ObservableCollection<Pin>();
        public ObservableCollection<Pin> PinCollection { get { return _pinCollection; } set { _pinCollection = value; OnPropertyChanged(); } }

        public Chatroom chatroomToJoin;
        User user;
        ChatroomList chatrooms;
        IDataStore DataStore;

        public enum joinChatroomResponse { SUCCESS, ERROR, DUPLICATE };

        public NearbyMapViewModel(Page page) : base(page)
        {
            DataStore = App.dataStore;
            GetCurrentPosition();
            PopulatePinsList();
        }

        private void PopulatePinsList()
        {
            Dictionary<string, Chatroom> chatrooms = DataStore.GetServerChatrooms().Result;
            foreach(Chatroom c in chatrooms.Values){
                double Longitude = c.Location[0];
                double Latitude = c.Location[1];
                Position pinPosition = new Position(Latitude, Longitude);
                Pin chatroomPin = new Pin() { Position = pinPosition, Type = PinType.Generic, Label = c.Title, Address = c.ID};
                PinCollection.Add(chatroomPin);

                chatroomPin.Clicked += (object sender, EventArgs e) => {
                    string chatroomID = ((Pin)sender).Address;
                    chatrooms.TryGetValue(((Pin)sender).Address, out chatroomToJoin);
                };

            }
        }

        private async void GetCurrentPosition(){
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                if (locator.IsGeolocationAvailable && locator.IsGeolocationEnabled)
                {
                    var position = await CrossGeolocator.Current.GetPositionAsync(TimeSpan.FromSeconds(20));
                    MyPosition = new Position(position.Latitude, position.Longitude);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to get location, may need to increase timeout: " + ex);
            }
        }

        public joinChatroomResponse joinChatroom(){
            user = DataStore.GetLocalUser().Result;
            chatrooms = DataStore.GetLocalChatrooms().Result;
            if (chatroomToJoin != null)
            {
                foreach (Chatroom c in chatrooms)
                {
                    if (c.ID == chatroomToJoin.ID)
                        return joinChatroomResponse.DUPLICATE;
                }
                chatrooms.Add(chatroomToJoin);
                user.ChatroomIDs.Add(chatroomToJoin.ID);
                DataStore.UpdateLocalUser(user);
                DataStore.UpdateLocalChatrooms(chatrooms);
                return joinChatroomResponse.SUCCESS;
            }else{
                return joinChatroomResponse.ERROR;
            }
        }
    }
}
