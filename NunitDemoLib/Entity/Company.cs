using System.Collections.Generic;

namespace NunitDemoLib.Entity
{
    public class Company
    {

        public string Name { get; }

        public List<Vehicle> Vehicles { get; }

        public Company(string name, List<Vehicle> vehicles)
        {
            Name = name;
            Vehicles = vehicles;
        }

        public override bool Equals(object obj)
        {
            Company other = obj as Company;
            return other.Name == this.Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}