using Xamarin.Forms;
using System.Diagnostics;
using LocalHost.Models;
using LocalHost.Views;
using LocalHost.ViewModels;

namespace LocalHost
{
    public partial class App : Application
    {
        public static AsyncDataStore dataStore = AsyncDataStore.CreateAsync().Result;
        public bool NoUserData = (dataStore.GetLocalUser().Result == null);

        public App()
        {
            if (NoUserData){
                MainPage = new MainPage();
                MainPage.Navigation.PushModalAsync(new NavigationPage(new WelcomePage()));
            }else{
                MainPage = new MainPage();
            }

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
