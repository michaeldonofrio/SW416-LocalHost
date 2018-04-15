using Xamarin.Forms;
using System.Diagnostics;
using LocalHost.Models;
using LocalHost.Views;
using LocalHost.ViewModels;

namespace LocalHost
{
    public partial class App : Application
    {
        public static AsyncMockDataStore dataStore;

        public App()
        {
            MainPage = new MainPage();

            var command = new Command(async () => { dataStore = await AsyncMockDataStore.CreateAsync(); });
            command.Execute(null);
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
