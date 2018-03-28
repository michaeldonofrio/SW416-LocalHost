using System.Collections.Generic;
using System.Threading.Tasks;
using LocalHost.Models;

namespace LocalHost
{
    public interface IDataStore
    {
        Task Init();
        Task<User> GetUser();
        Task<User> UpdateStore(User user);
        Task<Chatroom> AddChatroom(Chatroom chatroom);
        Task<Chatroom> GetChatrooms();
        Task<bool> RemoveChatroom(Chatroom feedback);
    }
}
