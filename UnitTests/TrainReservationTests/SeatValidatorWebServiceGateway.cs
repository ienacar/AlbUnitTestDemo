using NunitDemoLib.Entity;
using ReservationLib.Entity;
using ReservationLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.TrainReservationTests
{
    public class SeatValidatorWebServiceGateway : ISeatValidator
    {
        public DateTime LastCheckTime { get; private set; }

        public void Initialize()
        {
            //
        }

        public bool Validate(string vehicleId, string country, Seat seat, DateTime date)
        {
            bool isValidSeat;
            Connect();
            isValidSeat = CallService(vehicleId, country, seat, date,true);
            LastCheckTime = GetDatetimeNow();
            Disconnect();
            return isValidSeat;
        }

        public virtual DateTime GetDatetimeNow()
        {
            return DateTime.Now;
        }

        protected virtual bool CallService(string vehicleId, string country, Seat seat, DateTime date, bool flag)
        {
            return false;
        }

        private void Disconnect()
        {
            //connection close
        }

        private void Connect()
        {
            //connection set
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
