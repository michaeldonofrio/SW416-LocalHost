using System.Threading.Tasks;
using LocalHost.Models;
using Newtonsoft.Json;
using System.Reflection;
using Plugin.EmbeddedResource;
using System.Collections.Generic;
using System.Diagnostics;
using PCLStorage;
using Xamarin.Forms;
using System.Threading;

namespace LocalHost
{
    public class AsyncMockDataStore : IDataStore
    {
        IFolder rootFolder;
        IFolder dataFolder;
        IFile userDataFile;
        IFile chatroomsDataFile;
        List<IDataStoreSubscriber> listOfSubscribers;

        public AsyncMockDataStore()
        {
            var init = new Command(async () => { await InitializeAsync(); }) ;
            init.Execute(null);
            listOfSubscribers = new List<IDataStoreSubscriber>();
        }

        public static AsyncMockDataStore Create()
        {
            return new AsyncMockDataStore();
        }

        public async Task<ChatroomList> GetChatrooms()
        {
            ChatroomList ChatList = new ChatroomList();
            // One trouble is that chatroomsDataFile could be null.
            string chatroomsJson = await chatroomsDataFile.ReadAllTextAsync();
            var tempList = JsonConvert.DeserializeObject<List<Chatroom>>(chatroomsJson);

            foreach (Chatroom c in tempList)
            {
               ChatList.Add(c);
            }

            return ChatList;
        }

        public async Task<User> GetUser()
        {
            // One trouble is that userDataFile could be null.
            string userJson = await userDataFile.ReadAllTextAsync();
            return JsonConvert.DeserializeObject<User>(userJson);
        }

        // Really, this method needs to be completed before any other methods on the class are called.
        private async Task<AsyncMockDataStore> InitializeAsync()
        {
            rootFolder = FileSystem.Current.LocalStorage;
            dataFolder = await rootFolder.CreateFolderAsync("data_folder", CreationCollisionOption.OpenIfExists);
            userDataFile = await dataFolder.CreateFileAsync("user.json", CreationCollisionOption.OpenIfExists);
            chatroomsDataFile = await dataFolder.CreateFileAsync("chatrooms.json", CreationCollisionOption.OpenIfExists);

            Debug.WriteLine("Local data storage path: \n" + dataFolder.Path);

            //Load Mock data
            if (await GetUser() == null)
            {
                var userJson = ResourceLoader.GetEmbeddedResourceString(Assembly.Load(new AssemblyName("LocalHost")), "user.json");
                await userDataFile.WriteAllTextAsync(userJson);

                var chatroomsJson = ResourceLoader.GetEmbeddedResourceString(Assembly.Load(new AssemblyName("LocalHost")), "chatrooms.json");
                await chatroomsDataFile.WriteAllTextAsync(chatroomsJson);
            }

            NotifyAllSubscibersFinished();

            return this;
        }

        public Task<bool> UpdateChatrooms(ChatroomList chatrooms)
        {
            Debug.WriteLine(chatroomsDataFile.Path);
            string newChatroomListJson = JsonConvert.SerializeObject(chatrooms);
            chatroomsDataFile.WriteAllTextAsync(newChatroomListJson);

            return Task.FromResult(true);
        }

        public Task<bool> UpdateUser(User user)
        {
            string newUserJson = JsonConvert.SerializeObject(user);
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
    }
}