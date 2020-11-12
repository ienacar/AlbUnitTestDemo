using NunitDemoLib.Entity;
using NunitDemoLib.Message;
using System;

namespace ReservationLib.Entity
{
    public class TrainReservation : ReservationRequest
    {

        public Train Train { get; }
        public TrainReservation(Applicant applicant,
                                Location location,
                                Train train,
                                DateTime date) 
            : base (applicant,location,date)
        {
            Train = train;
        }

    }
}
