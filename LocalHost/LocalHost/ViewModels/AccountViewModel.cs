using System;
using System.Diagnostics;
using LocalHost.Models;
using Xamarin.Forms;

namespace LocalHost.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        IDataStore DataStore;
        public User user { get; set; }
        public string ID { get { return (user?.ID); }}
        public string Username { get { return (user?.Username); } }
        public string Name { get { return (user?.FirstName + " " + user?.LastName); }}
        public string Location { get { return (user?.Location[0] +", " + user?.Location[1]); }}
   

        public AccountViewModel(User user, Page page) : base(page)
        {
            this.user = user;
            DataStore = App.dataStore;
            var loadUser = new Command(async () => { 
                try 
                { 
                    user = await DataStore.GetUser(); 
                } 
                catch (Exception ex) 
                { 
                    Debug.WriteLine("AccountViewModel : " + ex.Message);
                } });
            loadUser.Execute(null);
        }

        public void updateUser(string updatedUsername, string updatedName)
        {
            user.Username = updatedUsername;
            DataStore.UpdateUser(user);
        }
    }
}
