using System;
using System.Diagnostics;
using LocalHost.Models;
using Xamarin.Forms;

namespace LocalHost.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        public User user { get; set; }
        public string Id { get { return (user.ID); } }
        public string Username { get {return (user.Username); } }
        public string FirstName { get {return (user.FirstName); } }
        public string LastName { get {return (user.LastName); } }
        public string Location { get { return (user.Location[0] +"\n" + user.Location[1]); }}
   

        public AccountViewModel(User user, Page page) : base(page)
        {
            this.user = user;
            getUserAccount();
        }

        public void getUserAccount(){
            IDataStore fakeData = new MockDataStore();
            User user = fakeData.GetUser();
            this.user = user;
        }
    }
}
