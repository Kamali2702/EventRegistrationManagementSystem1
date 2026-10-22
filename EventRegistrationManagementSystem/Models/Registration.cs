using System;
using System.Collections.Generic;
using System.Text;

namespace EventRegistrationManagementSystem.Models
{
    public class Registration : RegistrationBase
    {
        public int ParticipantId { get; set; }
        public int EventId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public decimal BaseFee { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalFee { get; set; }
        public string Status { get; set; }


        public Registration()
        {

        }  
        public Registration(
            int registrationId,
            int participantId,
            int eventId,
            DateTime registrationDate,
            decimal baseFee,
            decimal discountAmount,
            decimal finalFee,
            string status)
        {
            RegistrationId = registrationId;
            ParticipantId = participantId;
            EventId = eventId;
            RegistrationDate = registrationDate;
            BaseFee = baseFee;
            DiscountAmount = discountAmount;
            FinalFee = finalFee;
            Status = status;
        }
        public string GetRegistrationType()
        {
            return "Registration";
        }
    }
}

