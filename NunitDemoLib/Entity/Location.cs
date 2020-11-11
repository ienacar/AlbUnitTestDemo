using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitDemoLib.Entity
{
    public class Location
    {
        public string From { get; private set; }
        public string To { get; private set; }

        public Location(string from, string to)
        {
            From = from;
            To = to;
        }

        public override bool Equals(object obj)
        {
            Location other = obj as Location;
            return other.From == this.From && other.To == this.To;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
