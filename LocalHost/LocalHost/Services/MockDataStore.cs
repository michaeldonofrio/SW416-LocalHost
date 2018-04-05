using System;
using System.Threading.Tasks;
using LocalHost.Models;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using Plugin.EmbeddedResource;
using System.Collections.Generic;
using System.Diagnostics;

namespace LocalHost
{
    public class MockDataStore : IDataStore
    {
        public Chatroom AddChatroom(Chatroom chatroom)
        {
            throw new NotImplementedException();
        }

        public ChatroomList GetChatrooms()
        {
            ChatroomList ChatList = new ChatroomList();
            var chatroomsJson = ResourceLoader.GetEmbeddedResourceString(Assembly.Load(new AssemblyName("LocalHost")), "chatrooms.json");
            var tempList = JsonConvert.DeserializeObject<List<Chatroom>>(chatroomsJson);

            foreach (Chatroom c in tempList)
            {
                ChatList.Add(c);
            }

            return ChatList;
        }

        public User GetUser()
        {
            var userJson = ResourceLoader.GetEmbeddedResourceString(Assembly.Load(new AssemblyName("LocalHost")), "user.json");
            return JsonConvert.DeserializeObject<User>(userJson);
        }

        public Task Init()
        {
            throw new NotImplementedException();
        }

        public bool RemoveChatroom(Chatroom feedback)
        {
            throw new NotImplementedException();
        }
    }
}