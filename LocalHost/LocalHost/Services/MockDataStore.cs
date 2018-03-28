using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using LocalHost.Models;
using Newtonsoft.Json;

namespace LocalHost
{
    public class MockDataStore : IDataStore
    {
        public Task<Chatroom> AddChatroom(Chatroom chatroom)
        {
            throw new NotImplementedException();
        }

        public Task<Chatroom> GetChatrooms()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser()
        {
            throw new NotImplementedException();
        }

        public Task Init()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveChatroom(Chatroom feedback)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateStore(User user)
        {
            throw new NotImplementedException();
        }
    }
}
4