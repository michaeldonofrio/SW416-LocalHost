using System;
using System.Collections.Generic;
using LocalHost.Models;
using Xamarin.Forms;

namespace LocalHost.ViewModels
{
    public class LogInViewModel : ViewModelBase
    {
        User user;
        IDataStore DataStore;

        public LogInViewModel(Page page) : base (page)
        {
            DataStore = App.dataStore;
        }

        public bool LogIn(string Username, string Password)
        {
            Username = Username.ToLower();
            if (DataStore.GetServerUsers().Result.TryGetValue(Username, out user))
            {
                if (user.Password == Password){
                    DataStore.SetLocalUser(user);
                    return true;
                }else{
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
