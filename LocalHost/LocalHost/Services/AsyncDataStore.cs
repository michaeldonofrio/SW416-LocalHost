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
using LocalHost.ViewModels;

namespace LocalHost
{
    public class AsyncDataStore : IDataStore
    {
        IFolder rootFolder;
        IFolder dataFolder;
        IFile userDataFile;
        IFile chatroomsDataFile;

        List<IObserverViewModel> observerList = new List<IObserverViewModel>();

        public static Task<AsyncDataStore> CreateAsync()
        {
            var ret = new AsyncDataStore();
            return ret.InitializeAsync();
        }

        public async Task<ChatroomList> GetChatrooms()
        {
            ChatroomList ChatList = new ChatroomList();
            string chatroomsJson = chatroomsDataFile.ReadAllTextAsync().Result;
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
            string userJson = userDataFile.ReadAllTextAsync().Result;
            return JsonConvert.DeserializeObject<User>(userJson);
        }

        private async Task<AsyncDataStore> InitializeAsync()
        {
            rootFolder = FileSystem.Current.LocalStorage;
            dataFolder = rootFolder.CreateFolderAsync("data_folder", CreationCollisionOption.OpenIfExists).Result;
            userDataFile = dataFolder.CreateFileAsync("user.json", CreationCollisionOption.OpenIfExists).Result;
            chatroomsDataFile = dataFolder.CreateFileAsync("chatrooms.json", CreationCollisionOption.OpenIfExists).Result;

            Debug.WriteLine("Local data storage path: \n" + dataFolder.Path);

            ////Load init chatroom if first load
            if (GetUser().Result == null){
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
            NotifyObservers();
            return Task.FromResult(true);
        }

        public Task<bool> UpdateUser(User user)
        {
            string newUserJson = JsonConvert.SerializeObject(user);
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


    }
}