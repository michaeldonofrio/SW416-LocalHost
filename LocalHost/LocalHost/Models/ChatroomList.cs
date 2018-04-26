using System;
using System.Collections.Generic;

namespace LocalHost.Models
{
    public class ChatroomList : List<Chatroom>
    {
        public List<Chatroom> ChatList { get; set; }

        public ChatroomList(){
            ChatList = new List<Chatroom>();
        }
    }
}
