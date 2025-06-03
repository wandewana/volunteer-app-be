using System;
using System.Collections.Generic;

namespace volunteer_app_backend.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public Location Location { get; set; }
        public string Description { get; set; }
        public int RequiredVolunteers { get; set; }
        public int EnrolledVolunteers { get; set; }
        public string Status { get; set; }
        public Organizer Organizer { get; set; }
        public List<string> Requirements { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public Coordinates Coordinates { get; set; }
    }

    public class Coordinates
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class Organizer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Contact Contact { get; set; }
    }

    public class Contact
    {
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
