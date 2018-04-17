using System.Collections.Generic;
using System.Threading.Tasks;
using LocalHost.Models;
using LocalHost.ViewModels;

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
<<<<<<< HEAD
        void Subscribe(IObserverViewModel observer);
        void NotifyObservers();
=======
        void Subscribe(IDataStoreSubscriber subscriber);
>>>>>>> PJK_Review
    }
}
