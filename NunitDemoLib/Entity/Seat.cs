using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitDemoLib.Entity
{
    public class Seat
    {

        public int MinNumber { get { return 1;  }  }
        public int MaxNumber { get { return 21; } }
        public int SeatNumber { get; private set; }

        public decimal Price { get; set; }

        public Seat(int seatNumber)
        {
            if ((seatNumber < MinNumber) || (seatNumber > MaxNumber))
            {
                throw new ArgumentOutOfRangeException(nameof(seatNumber),
                    $"Please select a seat number between {MinNumber} and {MaxNumber}");
            }
            SeatNumber = seatNumber;

        }
        public void SetPrice(decimal price)
        {
            Price = price;
        }

        public decimal GetPrice()
        {
            return Price;
        }

        public override bool Equals(object obj)
        {
            return obj is Seat seat &&
                   SeatNumber == seat.SeatNumber;
        }
    }
}
