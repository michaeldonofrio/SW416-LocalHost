using System;
using System.Collections.Generic;
namespace LocalHost.Models
{
    public class Chatroom
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string[] Location { get; set; }
        public string[] ParticipantIDs { get; set; }
        public string AdminID { get; set; }

    }
}
