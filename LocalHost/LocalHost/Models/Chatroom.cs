using System;
using System.Collections.Generic;
namespace LocalHost.Models
{
    public class Chatroom
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public double[] Location { get; set; }
        public List<string> ParticipantIDs { get; set; }
        public string AdminID { get; set; }
        public SortedDictionary<string, Message> ChatLog { get; set; }
        public int messageCount { get; set; }

        public Chatroom(string title = "", string adminID = "")
        {
            ChatLog = new SortedDictionary<string, Message>();
            this.Title = title;
            this.AdminID = adminID;
            this.ID = Guid.NewGuid().ToString();
            this.Location = new double[] { 0, 0 };
            this.ParticipantIDs = new List<string>();
            ParticipantIDs.Add(adminID);
            Message initMessage = new Message();
            initMessage.LineText = ("Welcome to " + this.Title + "!");
            initMessage.MessageID = "";
            initMessage.SenderID = "";
            initMessage.SenderName = "LocalHost";
            this.ChatLog.Add("00000", initMessage);
        }
    }
}
