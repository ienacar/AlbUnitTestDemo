using NUnit.Framework.Constraints;
using NunitDemoLib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Reservation
{
    public class OfferedJourneyLocationConstaint : Constraint
    {
        public Location ExpectedLocation { get; }
        public OfferedJourneyLocationConstaint(Location expectedLocation)
        {
            ExpectedLocation = expectedLocation;
        }

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            OfferedJourney comparison = actual as OfferedJourney;
            
            if(comparison is null)
            {
                return new ConstraintResult(this,actual,ConstraintStatus.Failure);
            }

            if (comparison.Vehicle.Location.Equals(ExpectedLocation))
            {
                return new ConstraintResult(this, actual, ConstraintStatus.Success);
            }

            return new ConstraintResult(this, actual, ConstraintStatus.Failure);
        }
    }
}
