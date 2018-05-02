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
        IFolder localDataFolder;
        IFolder serverDataFolder;
        IFile localUserFile;
        IFile localChatroomsFile;
        IFile serverUsersFile;
        IFile serverChatroomsFile;

        Dictionary<String, User> serverUsers = new Dictionary<string, User>();
        Dictionary<String, Chatroom> serverChatrooms = new Dictionary<string, Chatroom>();

        List<IObserverViewModel> observerList = new List<IObserverViewModel>();

        public static Task<AsyncDataStore> CreateAsync()
        {
            var ret = new AsyncDataStore();
            return ret.InitializeAsync();
        }

        public async Task<ChatroomList> GetLocalChatrooms()
        {

            ChatroomList ChatList = new ChatroomList();
            string chatroomsJson = localChatroomsFile.ReadAllTextAsync().Result;
            var tempList = JsonConvert.DeserializeObject<List<Chatroom>>(chatroomsJson);

            if (tempList != null){
                foreach (Chatroom c in tempList)
                    {
                        ChatList.Add(c);
                    }
            }
            return ChatList;
        }

        public async Task<User> GetLocalUser()
        {
            string userJson = localUserFile.ReadAllTextAsync().Result;
            User user = JsonConvert.DeserializeObject<User>(userJson);
            return user;
        }

        private async Task<AsyncDataStore> InitializeAsync()
        {
            rootFolder = FileSystem.Current.LocalStorage;

            //Local Data
            localDataFolder = rootFolder.CreateFolderAsync("local_data", CreationCollisionOption.OpenIfExists).Result;
            localUserFile = localDataFolder.CreateFileAsync("local_user.json", CreationCollisionOption.OpenIfExists).Result;
            localChatroomsFile = localDataFolder.CreateFileAsync("local_chatrooms.json", CreationCollisionOption.OpenIfExists).Result;

            //Mock Server Data
            serverDataFolder = rootFolder.CreateFolderAsync("server_data", CreationCollisionOption.OpenIfExists).Result;
            serverUsersFile = serverDataFolder.CreateFileAsync("server_users.json", CreationCollisionOption.OpenIfExists).Result;
            serverChatroomsFile = serverDataFolder.CreateFileAsync("server_chatrooms.json", CreationCollisionOption.OpenIfExists).Result;

            Debug.WriteLine("Local data storage path: \n" + localDataFolder.Path);
            Debug.WriteLine("Server data storage path: \n" + serverDataFolder.Path);

            //Load mock server data
            var serverChatroomsJson = ResourceLoader.GetEmbeddedResourceString(Assembly.Load(new AssemblyName("LocalHost")), "server_chatrooms.json");
            serverChatroomsFile.WriteAllTextAsync(serverChatroomsJson).Wait();

            var serverUsersJson = ResourceLoader.GetEmbeddedResourceString(Assembly.Load(new AssemblyName("LocalHost")), "server_users.json");
            serverUsersFile.WriteAllTextAsync(serverUsersJson).Wait();

            serverChatrooms = GetServerChatrooms().Result;
            serverUsers = GetServerUsers().Result;

            if (GetLocalUser().Result != null)
                PullServerChatroomsToLocal().Wait();

            return this;
        }

        public Task<bool> UpdateLocalChatrooms(ChatroomList chatrooms)
        {
            string newChatroomListJson = JsonConvert.SerializeObject(chatrooms);
            localChatroomsFile.WriteAllTextAsync(newChatroomListJson).Wait();
            PushLocalChatroomsToServer(chatrooms);
            NotifyObservers();
            return Task.FromResult(true);
        }

        public Task<bool> SetNewLocalUser(User user)
        {
            string newUserJson = JsonConvert.SerializeObject(user);
            localUserFile.WriteAllTextAsync(newUserJson).Wait();
            UpdateServerUsers(user);
            PullServerChatroomsToLocal();
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

        public async Task<Dictionary<string, User>> GetServerUsers()
        {
            string serverUsersJson = serverUsersFile.ReadAllTextAsync().Result;
            return JsonConvert.DeserializeObject<Dictionary<String, User>>(serverUsersJson);
        }

        public async Task<Dictionary<string, Chatroom>> GetServerChatrooms()
        {
            string serverChatroomsJson = serverChatroomsFile.ReadAllTextAsync().Result;
            return JsonConvert.DeserializeObject<Dictionary <String,Chatroom>>(serverChatroomsJson);


        }

        public Task<bool> PullServerChatroomsToLocal(){
            ChatroomList chatroomListFromServer = new ChatroomList();
            serverChatrooms = GetServerChatrooms().Result;
            User user = GetLocalUser().Result;

            foreach (String chatroomID in user.ChatroomIDs)
            {
                Chatroom c = new Chatroom();
                serverChatrooms.TryGetValue(chatroomID, out c);
                chatroomListFromServer.Add(c);
            }

            string newChatroomListJson = JsonConvert.SerializeObject(chatroomListFromServer);
            localChatroomsFile.WriteAllTextAsync(newChatroomListJson).Wait();

            return Task.FromResult(true);
        }

        public Task<bool> PushLocalChatroomsToServer(ChatroomList chatrooms)
        {
            foreach(Chatroom chatroom in chatrooms){
                serverChatrooms[chatroom.ID] = chatroom;
            }

            string newServerChatroomListJson = JsonConvert.SerializeObject(serverChatrooms);
            serverChatroomsFile.WriteAllTextAsync(newServerChatroomListJson).Wait();
            return Task.FromResult(true);
        }

        public Task<bool> UpdateLocalUser(User user)
        {
            string newUserJson = JsonConvert.SerializeObject(user);
            localUserFile.WriteAllTextAsync(newUserJson).Wait();
            if (user != null)
            {
                UpdateServerUsers(user);
            }
            return Task.FromResult(true);
        }

        public Task<bool> UpdateServerUsers(User user)
        {
            serverUsers[user.Username] = user;
            string newServerUsersJson = JsonConvert.SerializeObject(serverUsers);
            serverUsersFile.WriteAllTextAsync(newServerUsersJson).Wait();
            return Task.FromResult(true);
        }
    }
}