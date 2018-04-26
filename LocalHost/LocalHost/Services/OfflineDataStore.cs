using System.Threading.Tasks;
using LocalHost.Models;
using Newtonsoft.Json;
using System.Reflection;
using Plugin.EmbeddedResource;
using System.Collections.Generic;
using System.Diagnostics;
using PCLStorage;
using Xamarin.Forms;

namespace LocalHost
{
    public class OfflineDataStore : IDataStore
    {
        public const string LOAD_FINISHED = "Finished";
        public bool noUserData = false;
        IFolder rootFolder;
        IFolder dataFolder;
        IFile userDataFile;
        IFile chatroomsDataFile;


        public async static Task<OfflineDataStore> CreateAsync()
        {
            var ret = new OfflineDataStore();
            return await ret.InitializeAsync();
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

        // Really, this method needs to be completed before any other methods on the class are called.
        private async Task<OfflineDataStore> InitializeAsync()
        {
            rootFolder = FileSystem.Current.LocalStorage;
            dataFolder = await rootFolder.CreateFolderAsync("data_folder", CreationCollisionOption.OpenIfExists);
            userDataFile = await dataFolder.CreateFileAsync("user.json", CreationCollisionOption.OpenIfExists);
            chatroomsDataFile = await dataFolder.CreateFileAsync("chatrooms.json", CreationCollisionOption.OpenIfExists);

            Debug.WriteLine("Local data storage path: \n" + dataFolder.Path);

            var user = await GetUser();
            if (user == null)
            {
                noUserData = true;
            }

            var chatRooms = await GetChatrooms();
            if (chatRooms == null)
            {
                var chatroomsJson = ResourceLoader.GetEmbeddedResourceString(Assembly.Load(new AssemblyName("LocalHost")), "init_chatrooms.json");
                await chatroomsDataFile.WriteAllTextAsync(chatroomsJson);
            }

            MessagingCenter.Send<OfflineDataStore>(this, LOAD_FINISHED);

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
    }
}