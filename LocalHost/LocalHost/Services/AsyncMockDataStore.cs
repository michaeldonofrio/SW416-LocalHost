using System;
using System.Threading.Tasks;
using LocalHost.Models;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using Plugin.EmbeddedResource;
using System.Collections.Generic;
using System.Diagnostics;
using PCLStorage;

namespace LocalHost
{
    public class AsyncMockDataStore : IDataStore
    {
        IFolder rootFolder;
        IFolder dataFolder;
        IFile userDataFile;
        IFile chatroomsDataFile;

        public static Task<AsyncMockDataStore> CreateAsync()
        {
            var ret = new AsyncMockDataStore();
            return ret.InitializeAsync();
        }

        public async Task<ChatroomList> GetChatrooms()
        {
            ChatroomList ChatList = new ChatroomList();
            string chatroomsJson = chatroomsDataFile.ReadAllTextAsync().Result;
            var tempList = JsonConvert.DeserializeObject<List<Chatroom>>(chatroomsJson);

            foreach (Chatroom c in tempList)
            {
               ChatList.Add(c);
            }

            return ChatList;
        }

        public async Task<User> GetUser()
        {
            string userJson = userDataFile.ReadAllTextAsync().Result;
            return JsonConvert.DeserializeObject<User>(userJson);
        }

        private async Task<AsyncMockDataStore> InitializeAsync()
        {
            rootFolder = FileSystem.Current.LocalStorage;
            dataFolder = rootFolder.CreateFolderAsync("data_folder", CreationCollisionOption.OpenIfExists).Result;
            userDataFile = dataFolder.CreateFileAsync("user.json", CreationCollisionOption.OpenIfExists).Result;
            chatroomsDataFile = dataFolder.CreateFileAsync("chatrooms.json", CreationCollisionOption.OpenIfExists).Result;

            Debug.WriteLine("Local data storage path: \n" + dataFolder.Path);

            //Load Mock data
            if (GetUser().Result == null){
                var userJson = ResourceLoader.GetEmbeddedResourceString(Assembly.Load(new AssemblyName("LocalHost")), "user.json");
                userDataFile.WriteAllTextAsync(userJson).Wait();

                var chatroomsJson = ResourceLoader.GetEmbeddedResourceString(Assembly.Load(new AssemblyName("LocalHost")), "chatrooms.json");
                chatroomsDataFile.WriteAllTextAsync(chatroomsJson).Wait();
            }
            return this;
        }

        public Task<bool> UpdateChatrooms(ChatroomList chatrooms)
        {
            Debug.WriteLine(chatroomsDataFile.Path);
            string newChatroomListJson = JsonConvert.SerializeObject(chatrooms);
            chatroomsDataFile.WriteAllTextAsync(newChatroomListJson).Wait();
            return Task.FromResult(true);
        }

        public Task<bool> UpdateUser(User user)
        {
            string newUserJson = JsonConvert.SerializeObject(user);
            userDataFile.WriteAllTextAsync(newUserJson).Wait();
            return Task.FromResult(true);
        }

    }
}