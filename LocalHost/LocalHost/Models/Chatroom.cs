using System;
using System.Collections.Generic;
namespace LocalHost.Models
{
    public class Chatroom
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string[] Location { get; set; }
        public List<User> Participants { get; set; }
        public User Admin { get; set; }
    }
}
