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
        public static OfflineDataStore dataStore;

        public App()
        {
            MainPage = new SplashPage();
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
