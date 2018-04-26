using System;
using System.Diagnostics;
using System.Threading.Tasks;
using LocalHost.Models;
using Xamarin.Forms;

namespace LocalHost.ViewModels
{
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
        {
            // Could use a container here, but for simplicity this is OK.
            DataStore = App.dataStore;
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
        }
    }
}