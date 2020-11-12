using NunitDemoLib.Entity;
using ReservationLib.Entity;
using ReservationLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.TrainReservationTests
{
    public class SeatValidatorImpl : ISeatValidator
    {
        public void Initialize()
        {
            //initialize
        }

        public bool Validate(string vehicleId, string country, Seat seat, DateTime date)
        {
            return true;
        }

        public void Validate(string vehicleId, string country, Seat seats, DateTime date, out bool isValid)
        {
            throw new NotImplementedException();
        }

        public void Validate(string vehicleId, string country, Seat seats, DateTime date, ref VerificationStatus status)
        {
            throw new NotImplementedException();
        }
    }
}
