using System.Collections.Generic;
using System.Threading.Tasks;
using LocalHost.Models;
using LocalHost.ViewModels;

namespace LocalHost
{
    public interface IDataStore
    {
        Task<User> GetLocalUser();
        Task<bool> SetNewLocalUser(User user);
        Task<bool> UpdateLocalUser(User user);
        Task<ChatroomList> GetLocalChatrooms();
        Task<bool> UpdateLocalChatrooms(ChatroomList chatrooms);

 
        Task<Dictionary<string, Chatroom>>  GetServerChatrooms();
        Task<bool> PullServerChatroomsToLocal();
        Task<bool> PushLocalChatroomsToServer(ChatroomList chatrooms);

        Task<Dictionary<string, User>> GetServerUsers();
        Task<bool> UpdateServerUsers(User user);



        void Subscribe(IObserverViewModel observer);
        void NotifyObservers();
    }
}
