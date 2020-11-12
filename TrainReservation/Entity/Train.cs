using NunitDemoLib.Entity;
using System;

namespace ReservationLib.Entity
{
    public class Train : Vehicle
    {
        public TrainSeat Seat { get;  }
        public Train(string vehicleId, Location location, TimeSpan deperture,TrainSeat seat, decimal price) 
            : base(vehicleId, location, deperture, price)
        {
            Seat = seat;
        }
    }
}
