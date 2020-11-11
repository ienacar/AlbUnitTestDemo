using NUnit.Framework;
using NUnit.Framework.Constraints;
using NunitDemoLib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Reservation
{
    [Category("Seat")]
    public class SeatShould
    {

        [Test]
        public void ReturnPrice()
        {
            //arrange
            Seat seat = new Seat(5);
            //act
            seat.SetPrice(100);

            //assert
            Assert.That(() => seat.GetPrice(),Is.EqualTo(100));
            Assert.That(() => seat.GetPrice(), new EqualConstraint(100));
        }

        [Test]
        public void ReturnSeatNumber()
        {
            //arrange
            Seat seat = new Seat(5);
            //act
            //assert
            Assert.That(seat.SeatNumber, Is.EqualTo(5));
        }

        [Test]
        public void ReturnSeatEquality()
        {
            //arrange
            Seat seat1 = new Seat(5);
            Seat seat2 = new Seat(5);
            //act
            //assert
            Assert.That(seat1, Is.EqualTo(seat2));
        }

        [Test]
        public void ReturnSeatRefEquality()
        {
            //arrange
            Seat seat1 = new Seat(5);
            Seat seat2 = new Seat(5);
            Seat seat3 = seat1;
            //act
            //assert
            Assert.That(seat1,Is.SameAs(seat3));
            Assert.That(seat1, Is.Not.SameAs(seat2));
        }

        [Test]
        public void ReturnRefEquality()
        {
            //arrange
            var list1 = new List<string> { "a", "b" };
            var list2 = new List<string> { "a", "b" };
            var list3 = list1;
            //act
            //assert
            Assert.That(list1, Is.SameAs(list3));
            Assert.That(list1, Is.Not.SameAs(list2));
        }

        [Test]
        public void ReturnFloatPointEquality()
        {
            double x = 1.0 / 3.0;
            Assert.That(x,Is.EqualTo(0.33).Within(0.004));
            Assert.That(x, Is.EqualTo(0.33).Within(10).Percent);
        }

        [Test]
        public void ReturnInvalidSeatNumber()
        {
            Assert.That(() => new Seat(0),Throws.TypeOf<ArgumentOutOfRangeException>());

            Assert.That(() => new Seat(0)
                        , Throws.TypeOf<ArgumentOutOfRangeException>()
                        .With
                        .Property("Message")
                        .EqualTo($"Please select a seat number between 1 and 21\r\nParameter name: seatNumber")
                       );

            Assert.That(() => new Seat(0)
                        , Throws.TypeOf<ArgumentOutOfRangeException>()
                        .With
                        .Property("ParamName")
                        .EqualTo($"seatNumber")
                       );

            Assert.That(() => new Seat(0)
                        , Throws.TypeOf<ArgumentOutOfRangeException>()
                        .With
                        .Matches<ArgumentOutOfRangeException> ( ex => ex.ParamName == "seatNumber")
                       );
        }
    }
}
