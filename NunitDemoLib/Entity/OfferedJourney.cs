using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitDemoLib.Entity
{
    public class OfferedJourney
    {
        public string Name { get; }

        public Vehicle Vehicle { get; }

        public OfferedJourney(string name, Vehicle vehicle, decimal price)
        {
            Name = name;
            Vehicle = vehicle;
        }

        public override bool Equals(object obj)
        {
            OfferedJourney other = obj as OfferedJourney;
            return other.Name == this.Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
