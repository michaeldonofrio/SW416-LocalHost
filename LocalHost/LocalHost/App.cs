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
<<<<<<< HEAD
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

=======
        public static IDataStore dataStore;

        public App()
        {
            dataStore = AsyncMockDataStore.Create();
            MainPage = new MainPage();
>>>>>>> PJK_Review
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
