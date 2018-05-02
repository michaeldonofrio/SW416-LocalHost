using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using MvvmHelpers;
using Plugin.Geolocator;

namespace LocalHost.Models
{
    public class User : ObservableObject
    {
        public double longitude;
        public double latitude;

        public string ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> ChatroomIDs { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string LocationString { get { return longitude + ", " + latitude; } }


        public double Longitude 
        { 
            get { return latitude; } 
            set{  SetProperty(ref latitude, value);} 
        }

        public double Latitude
        {
            get { return longitude; }
            set { SetProperty(ref longitude, value); }
        }

        public User(string Username, string Password, string FirstName, string LastName)
        {
            this.ID = "";
            this.Username = Username;
            this.Password = Password;
            this.FirstName = FirstName;
            this.LastName = LastName;
            longitude = 0.000;
            latitude = 0.000;
            ChatroomIDs = new List<string>();
            ChatroomIDs.Add("00000");
        }
    }
}
