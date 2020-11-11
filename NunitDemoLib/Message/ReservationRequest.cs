using NunitDemoLib.Entity;
using System;

namespace NunitDemoLib.Message
{
    public class ReservationRequest : Reservation
    {
        public ReservationRequest(Applicant applicant, Location location, DateTime date) : base(applicant, location, date)
        {
        }
    }
}
