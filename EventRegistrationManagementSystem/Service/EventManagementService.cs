using System;
using System.Linq;
using System.Collections.Generic;
using EventRegistrationManagementSystem.Models;

namespace EventRegistrationManagementSystem.Service
{
    public class EventManagementService
    {
        private Dictionary<int, Event> events = new Dictionary<int, Event>();

        public Event CreateEvent(int eventId, string EventName, string venue, DateTime eventDate, int capacity, decimal registrationFee)
        {
            if (events.ContainsKey(eventId))
            {
                throw new ArgumentException($"An event with ID already exists.");
            }
            if (string.IsNullOrWhiteSpace(EventName))
            {
                throw new ArgumentException("Event name cannot be empty.");
            }
            if (string.IsNullOrWhiteSpace(venue))
            {
                throw new ArgumentException("Venue cannot be empty.");
            }
            if (eventDate <= DateTime.Now)
            {
                throw new ArgumentException("Event date must be in the future.");
            }
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be positive.");
            }
            if (registrationFee < 0)
            {
                throw new ArgumentException("No negative Fee.");
            }
            Event newEvent = new Event();
            newEvent.EventId = eventId;
            newEvent.EventName = EventName;
            newEvent.Venue = venue;
            newEvent.EventDate = eventDate;
            newEvent.Capacity = capacity;
            newEvent.RegistrationFee = registrationFee;

            events[eventId] = newEvent;
            return newEvent;
        }
        public List<Event> GetAllEvents()
        {
            return new List<Event>(events.Values);
        }
        public List<Event> SearchEvent(string msg)
        {
            return events.Values.Where(e => e.EventName.Contains(msg, StringComparison.OrdinalIgnoreCase)
            || e.Venue.Contains(msg, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        public UpdateEvent(int eventId, string eventName, string venue, DateTime eventDate, int capacity, decimal registrationFee)
    }
}