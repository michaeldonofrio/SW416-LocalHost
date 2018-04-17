using System;
using System.Diagnostics;
using System.Threading.Tasks;
using LocalHost.Models;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace LocalHost.ViewModels
{
<<<<<<< HEAD
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
=======
    public class AccountViewModel : ViewModelBase, IDataStoreSubscriber
    {
        IDataStore DataStore;
        public User User { get; set; }
        public string ID { get { return (User?.ID); }}
        public string Username { get { return (User?.Username); } }
        public string Name { get { return (User?.FirstName + " " + User?.LastName); }}
        public string Location { get { return (User?.Location[0] +", " + User?.Location[1]); }}
   
        public AccountViewModel(Page page) : base(page)
        {
            // Could use a container here, but for simplicity this is OK.
            DataStore = App.dataStore;
            DataStore.Subscribe(this);
        }

        public void updateUser(string updatedUsername, string updatedName)
        {
>>>>>>> PJK_Review
            User.Username = updatedUsername;
            DataStore.UpdateUser(User);
        }

<<<<<<< HEAD
        public void getData()
        {
            User user = DataStore.GetUser().Result;
            this.User = user;
=======
        public async Task FinshedLoading(IDataStore dataStore)
        {
            User = await DataStore.GetUser();
>>>>>>> PJK_Review
        }
    }
}
