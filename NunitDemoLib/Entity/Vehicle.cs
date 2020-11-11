using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitDemoLib.Entity
{
    public class Vehicle
    {
        public string VehicleId { get;}

        public Location Location { get; }

        public TimeSpan Deperture { get; }

        public decimal Price { get; }

        public Vehicle(string vehicleId, Location location , TimeSpan deperture,decimal price)
        {
            VehicleId = vehicleId;
            Location = location;
            Deperture = deperture;
            Price = price;
        }
    }
}
