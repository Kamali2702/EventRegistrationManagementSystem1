 using System;
using System.Collections.Generic;
using System.Text;

namespace EventRegistrationManagementSystem.Models
{
    public class Event
    {
        public int EventId { get; set; } 
        public string EventName { get; set; }
        public string Venue { get; set; }
        public DateTime EventDate { get; set; }
        public int Capacity { get; set; }
        public decimal RegistrationFee { get; set; }

    public Event()
        {

        }
        public Event(int eventId, string eventName, string venue, DateTime eventDate, int capacity, decimal registrationFee)
        {
            EventId = eventId;
            EventName = eventName;
            Venue = venue;
            EventDate = eventDate;
            Capacity = capacity;
            RegistrationFee = registrationFee;
        }
    }
}