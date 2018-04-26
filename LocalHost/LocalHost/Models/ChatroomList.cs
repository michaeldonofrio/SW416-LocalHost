using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LocalHost.Models
{
    public class ChatroomList : ObservableCollection<Chatroom>
    {
<<<<<<< HEAD
=======
        public List<Chatroom> ChatList { get; set; }

        public ChatroomList(){
            ChatList = new List<Chatroom>();
        }
>>>>>>> SignUp/SignIn-Page
    }
}
