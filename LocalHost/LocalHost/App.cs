using Xamarin.Forms;
using System.Diagnostics;
using LocalHost.Models;
using LocalHost.Views;
using LocalHost.ViewModels;
using System.Threading.Tasks;

namespace LocalHost
{
    public partial class App : Application
    {
        public static AsyncMockDataStore dataStore;

        public App()
        {
            dataStore = AsyncMockDataStore.Create();

            MainPage = new MainPage();
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
