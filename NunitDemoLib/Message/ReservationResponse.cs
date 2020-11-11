using NunitDemoLib.Entity;
using System;

namespace NunitDemoLib.Message
{
    public class ReservationResponse : Reservation
    {
        public OfferedJourney Company { get; set; }


        public ReservationResponse(Applicant applicant, Location location, DateTime date) : base(applicant, location, date)
        {

        }


        public void SetCompany(OfferedJourney company)
        {
            Company = company;
        }
    }
}
