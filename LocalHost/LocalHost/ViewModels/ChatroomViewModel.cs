using System;
using System.Collections.Generic;
using System.Diagnostics;
using LocalHost.Models;
using Xamarin.Forms;

namespace LocalHost.ViewModels
{
    public class ChatroomViewModel : ViewModelBase
    {
        public Chatroom chatroom { get; set; }
        public string ID { get { return (chatroom.ID); } }
        public string Title { get { return (chatroom.Title); } }
        public string[] Location { get { return (chatroom.Location); } }
        public List<string> ParticipantIDs { get { return (chatroom.ParticipantIDs); } }
        public string AdminID { get { return (chatroom.AdminID); } }
        public SortedDictionary<string, Message> ChatLog { get { return (chatroom.ChatLog); } }

        public ChatroomViewModel(Chatroom chatroom, Page page) : base(page)
        {
            this.chatroom = chatroom;
        }
    }
}
