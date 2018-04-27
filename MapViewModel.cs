using System;
using System.Diagnostics;
using LocalHost.Models;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace LocalHost.ViewModels
{
    public class MapViewModel : ViewModelBase, IObserverViewModel
    {
        IDataStore DataStore;
        private User user;
        public User User { get { return user; }
                           set { SetProperty(ref user, value); }}

        public MapViewModel(User user, Page page) : base(page)
        {
            this.User = user;
            DataStore = App.dataStore;
            DataStore.Subscribe(this);
            getData();
        }

        /*public void updateUser(string updatedUsername, string updatedName){
            User.Username = updatedUsername;
            DataStore.UpdateUser(User);
        }*/

        public void getData()
        {
            User user = DataStore.GetUser().Result;
            this.User = user;
        }
    }
}
