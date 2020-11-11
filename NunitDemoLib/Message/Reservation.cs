using NunitDemoLib.Entity;
using System;

namespace NunitDemoLib.Message
{
    public class Reservation
    {
        public Guid Id { get; }
        public Applicant Applicant { get; private set; }

        public Location Location { get; private set; }

        public DateTime Date { get; private set; }

        private bool isValid;

        public Reservation(Applicant applicant,Location location,DateTime date)
        {
            Id = new Guid();
            Applicant = applicant;
            Location = location;
            Date = date;
        }

        public bool IsValid()
        {
            return isValid;
        }

        public void Accept()
        {
            isValid = true;
        }

        public void Decline()
        {
            isValid = false;
        }
    }
}
