using System;
namespace LocalHost.Models
{
    public class User
    {
        public string ID { get; set; }
        public string Username { get; set;  }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] Location { get; set; }
        public string[] ChatroomIDs { get; set; }
    }
}
