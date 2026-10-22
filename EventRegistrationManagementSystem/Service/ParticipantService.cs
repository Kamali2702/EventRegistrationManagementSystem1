using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EventRegistrationManagementSystem.Models;

namespace EventRegistrationManagementSystem.Service
{
    public class ParticipantService
    {
        private Dictionary<int, Participant> participants = new Dictionary<int, Participant>();
        public Participant CreateParticipant(int participantId,
            string fullName,
            string email,
            string phoneNumber)
        {

            if (participants.ContainsKey(participantId))
            {
                throw new ArgumentException($"Participant with ID {participantId} already exists.");
            }
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Full name cannot be empty.");
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be empty.");
            }
            if (phoneNumber.Length != 10 || !phoneNumber.All(char.IsDigit))
            {
                throw new ArgumentException("Phone number must contain exactly 10 digits.");
            }
            Participant newParticipant = new Participant();
            newParticipant.ParticipantId = participantId;
            newParticipant.FullName = fullName;
            newParticipant.Email = email;
            newParticipant.PhoneNumber = phoneNumber;

            participants[participantId] = newParticipant;
            return newParticipant;

        }
        public List<Participant> GetAllParticipants()
        {
            return participants.Values.ToList();
        }
        public Participant GetParticipantById(int participantId)
        {
            if (!participants.ContainsKey(participantId))
            {
                throw new ArgumentException(
                    $"No participant found with ID {participantId}.");
            }

            return participants[participantId];
        }
        public Participant UpdateParticipant(
            int participantId,
            string fullName,
            string email,
            string phoneNumber)
        {
            if (!participants.ContainsKey(participantId))
                {
                 throw new ArgumentException($"No participant found with ID {participantId}.");
            }

            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Full name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be empty.");
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                throw new ArgumentException("Enter a valid email address.");
            }

            if (phoneNumber.Length != 10 || !phoneNumber.All(char.IsDigit))
            {
                throw new ArgumentException("Phone number must contain exactly 10 digits.");
            }

            Participant existingParticipant = participants[participantId];

            existingParticipant.FullName = fullName;
            existingParticipant.Email = email;
            existingParticipant.PhoneNumber = phoneNumber;

            return existingParticipant;
        }
        public List<Participant> SearchParticipant(string searchText)
        {
            return participants.Values
                .Where(p =>
                    p.FullName.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                    p.Email.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
