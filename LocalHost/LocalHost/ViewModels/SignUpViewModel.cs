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

        public bool CreateUser(string Username, string Password, string FirstName, string LastName){
            Username = Username.ToLower();
            if (DataStore.GetServerUsers().Result.ContainsKey(Username)){
                return false;
            }else {
                newUser = new User(Username, Password, FirstName, LastName);
                DataStore.SetNewLocalUser(newUser);
                return true;
            }
        }
    }
}