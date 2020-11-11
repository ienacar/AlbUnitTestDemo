using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Reservation
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,AllowMultiple = false)]
    public class SeatCategoryAttribute : CategoryAttribute
    {
    }
}
