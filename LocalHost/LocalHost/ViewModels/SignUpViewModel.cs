using System;
using LocalHost.Models;
using Xamarin.Forms;

namespace LocalHost.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        IDataStore DataStore;
        User newUser;

        public SignUpViewModel (Page page) : base(page)
        {
            DataStore = App.dataStore;
        }

        public void CreateUser(string Username, string FirstName, string Lastname){
            newUser = new User(Username, FirstName, Lastname);
            DataStore.UpdateUser(newUser);
        }
    }
}