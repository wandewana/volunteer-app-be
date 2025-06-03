using System;
using System.Collections.Generic;

namespace volunteer_app_backend.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int VolunteerId { get; set; }
        public string Status { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Notes { get; set; }
        public List<string> Roles { get; set; }
        public CheckIn CheckIn { get; set; }
    }

    public class CheckIn
    {
        public string Status { get; set; }
        public DateTime? Time { get; set; }
    }
}
