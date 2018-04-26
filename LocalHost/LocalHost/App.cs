using Xamarin.Forms;
using System.Diagnostics;
using LocalHost.Models;
using LocalHost.Views;
using LocalHost.ViewModels;

namespace LocalHost
{
    public partial class App : Application
    {
<<<<<<< HEAD
        public static OfflineDataStore dataStore;

        public App()
        {
            MainPage = new SplashPage();
=======
        public static AsyncDataStore dataStore = AsyncDataStore.CreateAsync().Result;
        public bool NoUserData = (dataStore.GetUser().Result == null);

        public App()
        {
            if (NoUserData){
                MainPage = new MainPage();
                MainPage.Navigation.PushModalAsync(new SignUpPage());
            }else{
                MainPage = new MainPage();
            }

>>>>>>> SignUp/SignIn-Page
        }

        protected async override void OnStart()
        {
            dataStore = await OfflineDataStore.CreateAsync();
            Debug.WriteLine(dataStore.noUserData);

            if (dataStore.noUserData)
            {
                MainPage = new MainPage();
                await MainPage.Navigation.PushModalAsync(new SignUpPage());
            }
            else
            {
                MainPage = new MainPage();
            }

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
