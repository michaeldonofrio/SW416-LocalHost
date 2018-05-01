using System.Collections.Generic;
using System.Threading.Tasks;
using LocalHost.Models;
using LocalHost.ViewModels;

namespace LocalHost
{
    public interface IDataStore
    {
        Task<User> GetLocalUser();
        Task<bool> SetLocalUser(User user);
        Task<ChatroomList> GetLocalChatrooms();
        Task<bool> UpdateLocalChatrooms(ChatroomList chatrooms);

        Task<Dictionary<string, User>> GetServerUsers();
        Task<bool> UpdateServerUsers (Dictionary<string, User> users);
        Task<Dictionary<string, Chatroom>>  GetServerChatrooms();
        Task<bool> UpdateServerChatrooms(Dictionary<string, Chatroom> chatrooms);

        void Subscribe(IObserverViewModel observer);
        void NotifyObservers();
    }
}
