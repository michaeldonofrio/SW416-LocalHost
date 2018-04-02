using System.Collections.Generic;
using System.Threading.Tasks;
using LocalHost.Models;

namespace LocalHost
{
    public interface IDataStore
    {
        Task Init();
        User GetUser();
        bool UpdateUser(User user);
        ChatroomList GetChatrooms();
        bool AddChatroom(Chatroom chatroom);
        bool RemoveChatroom(Chatroom chatroom);
     
      
    }
}
