using System;
using System.Collections.Generic;

namespace volunteer_app_backend.Models
{
    public class Volunteer
    {
        public int Id { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public Availability Availability { get; set; }
        public List<string> Skills { get; set; }
        public Preferences Preferences { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class PersonalInfo
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }
    }

    public class Availability
    {
        public List<string> PreferredDays { get; set; }
        public List<string> PreferredTimes { get; set; }
        public bool Flexible { get; set; }
    }

    public class Preferences
    {
        public List<string> EventTypes { get; set; }
        public string Distance { get; set; }
        public NotificationPreferences NotificationPreferences { get; set; }
    }

    public class NotificationPreferences
    {
        public bool Email { get; set; }
        public bool Sms { get; set; }
        public bool Push { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
