using System;
using System.Diagnostics;
using System.Threading.Tasks;
using LocalHost.Models;
using Xamarin.Forms;

namespace LocalHost.ViewModels
{
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
            User.Username = updatedUsername;
            DataStore.UpdateUser(User);
        }

        public async Task FinshedLoading(IDataStore dataStore)
        {
            User = await DataStore.GetUser();
        }
    }
}
