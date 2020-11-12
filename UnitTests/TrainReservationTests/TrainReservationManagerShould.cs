using NUnit.Framework;
using NUnit.Framework.Constraints;
using NunitDemoLib.Entity;
using ReservationLib;
using ReservationLib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.TrainReservationTests
{
    public class TrainReservationManagerShould
    {
        [Test]
        public void DeclineReservationForDate()
        {
            //arrange
            Applicant applicant = new Applicant("ibrahim","11111111111",19);
            Location location = new Location("IST", "ANK");
            Train train = new Train("YHT1",location,new TimeSpan(7,00,00),new TrainSeat("1",1),100);
            TrainReservation request = new TrainReservation(applicant,location,train,new DateTime(2020,12,12));

            TrainReservationManager manager = new TrainReservationManager(null, null);
            //act
            manager.MakeReservation(request);
            //assert
            Assert.That(request.IsValid, Is.False);
        }

        [Ignore("Unvalid request")]
        [Test]
        public void ReservationForDateForUnsatisfiedDependency()
        {
            //arrange
            Applicant applicant = new Applicant("ibrahim", "11111111111", 19);
            Location location = new Location("IST", "ANK");
            Train train = new Train("YHT1", location, new TimeSpan(7, 00, 00), new TrainSeat("1", 1), 100);
            TrainReservation request = new TrainReservation(applicant, location, train, new DateTime(2020, 11, 12));

            TrainReservationManager manager = new TrainReservationManager(null, null);
            //act
            manager.MakeReservation(request);
            //assert
            Assert.That(request.IsValid, Is.False);
        }

        [Test]
        public void UnvalidSeatTestWithImpl()
        {
            //arrange
            Applicant applicant = new Applicant("ibrahim", "11111111111", 19);
            Location location = new Location("IST", "ANK");
            Train train = new Train("YHT1", location, new TimeSpan(7, 00, 00), new TrainSeat("1", 1), 100);
            TrainReservation request = new TrainReservation(applicant, location, train, new DateTime(2020, 11, 12));

            var seatValidator = new SeatValidatorImpl();
            TrainReservationManager manager = new TrainReservationManager(seatValidator, null);
            //act
            manager.MakeReservation(request);
            //assert
            Assert.That(request.IsValid, Is.True);
        }
    }
}
