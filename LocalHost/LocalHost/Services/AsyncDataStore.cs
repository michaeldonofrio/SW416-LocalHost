using System.Threading.Tasks;
using LocalHost.Models;
using Newtonsoft.Json;
using System.Reflection;
using Plugin.EmbeddedResource;
using System.Collections.Generic;
using System.Diagnostics;
using PCLStorage;
<<<<<<< HEAD:LocalHost/LocalHost/Services/AsyncDataStore.cs
using LocalHost.ViewModels;
=======
using Xamarin.Forms;
using System.Threading;
>>>>>>> PJK_Review:LocalHost/LocalHost/Services/AsyncMockDataStore.cs

namespace LocalHost
{
    public class AsyncDataStore : IDataStore
    {
        IFolder rootFolder;
        IFolder dataFolder;
        IFile userDataFile;
        IFile chatroomsDataFile;
        List<IDataStoreSubscriber> listOfSubscribers;

<<<<<<< HEAD:LocalHost/LocalHost/Services/AsyncDataStore.cs
        List<IObserverViewModel> observerList = new List<IObserverViewModel>();

        public static Task<AsyncDataStore> CreateAsync()
        {
            var ret = new AsyncDataStore();
            return ret.InitializeAsync();
=======
        public AsyncMockDataStore()
        {
            var init = new Command(async () => { await InitializeAsync(); }) ;
            init.Execute(null);
            listOfSubscribers = new List<IDataStoreSubscriber>();
        }

        public static AsyncMockDataStore Create()
        {
            return new AsyncMockDataStore();
>>>>>>> PJK_Review:LocalHost/LocalHost/Services/AsyncMockDataStore.cs
        }

        public async Task<ChatroomList> GetChatrooms()
        {
            ChatroomList ChatList = new ChatroomList();
            // One trouble is that chatroomsDataFile could be null.
            string chatroomsJson = await chatroomsDataFile.ReadAllTextAsync();
            var tempList = JsonConvert.DeserializeObject<List<Chatroom>>(chatroomsJson);

            if (tempList != null){
                foreach (Chatroom c in tempList)
                    {
                        ChatList.Add(c);
                    }
            }
            return ChatList;
        }

        public async Task<User> GetUser()
        {
            // One trouble is that userDataFile could be null.
            string userJson = await userDataFile.ReadAllTextAsync();
            return JsonConvert.DeserializeObject<User>(userJson);
        }

<<<<<<< HEAD:LocalHost/LocalHost/Services/AsyncDataStore.cs
        private async Task<AsyncDataStore> InitializeAsync()
=======
        // Really, this method needs to be completed before any other methods on the class are called.
        private async Task<AsyncMockDataStore> InitializeAsync()
>>>>>>> PJK_Review:LocalHost/LocalHost/Services/AsyncMockDataStore.cs
        {
            rootFolder = FileSystem.Current.LocalStorage;
            dataFolder = await rootFolder.CreateFolderAsync("data_folder", CreationCollisionOption.OpenIfExists);
            userDataFile = await dataFolder.CreateFileAsync("user.json", CreationCollisionOption.OpenIfExists);
            chatroomsDataFile = await dataFolder.CreateFileAsync("chatrooms.json", CreationCollisionOption.OpenIfExists);

            Debug.WriteLine("Local data storage path: \n" + dataFolder.Path);

<<<<<<< HEAD:LocalHost/LocalHost/Services/AsyncDataStore.cs
            ////Load init chatroom if first load
            if (GetUser().Result == null){
=======
            //Load Mock data
            if (await GetUser() == null)
            {
                var userJson = ResourceLoader.GetEmbeddedResourceString(Assembly.Load(new AssemblyName("LocalHost")), "user.json");
                await userDataFile.WriteAllTextAsync(userJson);

>>>>>>> PJK_Review:LocalHost/LocalHost/Services/AsyncMockDataStore.cs
                var chatroomsJson = ResourceLoader.GetEmbeddedResourceString(Assembly.Load(new AssemblyName("LocalHost")), "chatrooms.json");
                await chatroomsDataFile.WriteAllTextAsync(chatroomsJson);
            }

<<<<<<< HEAD:LocalHost/LocalHost/Services/AsyncDataStore.cs
=======
            NotifyAllSubscibersFinished();

>>>>>>> PJK_Review:LocalHost/LocalHost/Services/AsyncMockDataStore.cs
            return this;
        }

        public Task<bool> UpdateChatrooms(ChatroomList chatrooms)
        {
            Debug.WriteLine(chatroomsDataFile.Path);
            string newChatroomListJson = JsonConvert.SerializeObject(chatrooms);
<<<<<<< HEAD:LocalHost/LocalHost/Services/AsyncDataStore.cs
            chatroomsDataFile.WriteAllTextAsync(newChatroomListJson).Wait();
            NotifyObservers();
=======
            chatroomsDataFile.WriteAllTextAsync(newChatroomListJson);

>>>>>>> PJK_Review:LocalHost/LocalHost/Services/AsyncMockDataStore.cs
            return Task.FromResult(true);
        }

        public Task<bool> UpdateUser(User user)
        {
            string newUserJson = JsonConvert.SerializeObject(user);
<<<<<<< HEAD:LocalHost/LocalHost/Services/AsyncDataStore.cs
            userDataFile.WriteAllTextAsync(newUserJson).Wait();
            NotifyObservers();
            return Task.FromResult(true);
        }

        public void Subscribe(IObserverViewModel observer)
        {
            observerList.Add(observer);
        }


        public void NotifyObservers(){
            foreach (IObserverViewModel observer in observerList){
                observer.getData();
            }
        }


=======
            userDataFile.WriteAllTextAsync(newUserJson);

            return Task.FromResult(true);
        }

        void IDataStore.Subscribe(IDataStoreSubscriber subscriber)
        {
            listOfSubscribers.Add(subscriber);
        }

        void NotifyAllSubscibersFinished()
        {
            foreach (var subscriber in listOfSubscribers)
            {
                // This has to be called asynchronously or else you'll get a lock-up.
                var cmd = new Command(async () => { await subscriber.FinshedLoading(this); });
                cmd.Execute(null);
            }
        }
>>>>>>> PJK_Review:LocalHost/LocalHost/Services/AsyncMockDataStore.cs
    }
}