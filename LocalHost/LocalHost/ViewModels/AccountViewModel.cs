using System;
using System.Diagnostics;
using LocalHost.Models;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace LocalHost.ViewModels
{
<<<<<<< HEAD
    public class AccountViewModel : ViewModelBase
    {
        IDataStore DataStore;
        private User user;
        public User User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }
   
        public AccountViewModel(Page page) : base(page)
=======
    public class AccountViewModel : ViewModelBase, IObserverViewModel
    {
        IDataStore DataStore;
        private User user;
        public User User { get { return user; }
                           set { SetProperty(ref user, value); }}

        public AccountViewModel(User user, Page page) : base(page)
>>>>>>> SignUp/SignIn-Page
        {
            this.User = user;
            DataStore = App.dataStore;
<<<<<<< HEAD
            MessagingCenter.Subscribe<OfflineDataStore>(this, OfflineDataStore.LOAD_FINISHED, (sender) => { Update(); });
        }

        private async void Update()
        {
            User = await DataStore.GetUser();
        }

        public void updateUser(string updatedUsername, string updatedName)
        {
            User.Username = updatedUsername;
            DataStore.UpdateUser(User);
=======
            DataStore.Subscribe(this);
            getData();
        }

        public void updateUser(string updatedUsername, string updatedName){
            User.Username = updatedUsername;
            DataStore.UpdateUser(User);
        }

        public void getData()
        {
            User user = DataStore.GetUser().Result;
            this.User = user;
>>>>>>> SignUp/SignIn-Page
        }
    }
}