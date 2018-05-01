using System;
using System.Diagnostics;
using LocalHost.Models;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace LocalHost.ViewModels
{
    public class AccountViewModel : ViewModelBase, IObserverViewModel
    {
        IDataStore DataStore;
        private User user;
        public User User { get { return user; }
                           set { SetProperty(ref user, value); }}

        public AccountViewModel(User user, Page page) : base(page)
        {
            this.User = user;
            DataStore = App.dataStore;
            DataStore.Subscribe(this);
            getData();
        }

        public void updateUser(string updatedUsername, string updatedName){
            User.Username = updatedUsername;
            DataStore.SetLocalUser(User);
        }

        public void getData()
        {
            User user = DataStore.GetLocalUser().Result;
            this.User = user;
        }
    }
}
