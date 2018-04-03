using System;
using System.Diagnostics;
using LocalHost.Models;
using Xamarin.Forms;

namespace LocalHost.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        public User user { get; set; }
        public string ID { get { return (user.ID); } }
        public string Username { get {return (user.Username); } }
        public string Name { get {return (user.FirstName + " " + user.LastName); } }
        public string Location { get { return (user.Location[0] +", " + user.Location[1]); }}
   

        public AccountViewModel(User user, Page page) : base(page)
        {
            this.user = user;
            getUserAccount();
        }

        private void getUserAccount(){
            IDataStore fakeData = new MockDataStore();
            User user = fakeData.GetUser();
            this.user = user;
        }
    }
}
