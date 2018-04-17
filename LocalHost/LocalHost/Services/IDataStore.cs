﻿using System.Collections.Generic;
using System.Threading.Tasks;
using LocalHost.Models;

namespace LocalHost
{
    public interface IDataStoreSubscriber
    {
        Task FinshedLoading(IDataStore dataStore);
    }
    public interface IDataStore
    {
        Task<User> GetUser();
        Task<bool> UpdateUser(User user);
        Task<ChatroomList> GetChatrooms();
        Task<bool> UpdateChatrooms(ChatroomList chatrooms);
        void Subscribe(IDataStoreSubscriber subscriber);
    }
}
