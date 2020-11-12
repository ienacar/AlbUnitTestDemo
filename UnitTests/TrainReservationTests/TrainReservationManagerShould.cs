using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NunitDemoLib.Entity;
using ReservationLib;
using ReservationLib.Entity;
using ReservationLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.TrainReservationTests
{
    public class TrainReservationManagerShould
    {
        TrainReservation request;
        Applicant applicant;
        Location location;
        Train train;

        [SetUp]
        public void Setup()
        {
            applicant = new Applicant("ibrahim", "11111111111", 19);
            location = new Location("IST", "ANK");
            train = new Train("YHT1", location, new TimeSpan(7, 00, 00), new TrainSeat("1", 1), 100);
            request = new TrainReservation(applicant, location, train, new DateTime(2020, 11, 12));
        }

        [Test]
        public void DeclineReservationForDate()
        {
            //arrange
            TrainReservationManager manager = new TrainReservationManager(null, null);
            request = new TrainReservation(applicant, location, train, new DateTime(2020, 12, 12));
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
            var seatValidator = new SeatValidatorImpl();
            TrainReservationManager manager = new TrainReservationManager(seatValidator, null);
            //act
            manager.MakeReservation(request);
            //assert
            Assert.That(request.IsValid, Is.True);
        }

        [Test]
        public void DeclineRequestWithMoqDependencyNoSetup()
        {
            //arrange
            var mockSeatValidator = new Mock<ISeatValidator>();
            var mockApplicantValidator = new Mock<IApplicantValidator>();

            TrainReservationManager manager = new TrainReservationManager(mockSeatValidator.Object, mockApplicantValidator.Object);
            //act
            manager.MakeReservation(request);
            //assert
            Assert.That(request.IsValid, Is.False);
        }

        [Test]
        public void AcceptRequestWithMoqDependencyWithSetup()
        {
            //arrange
            var mockSeatValidator = new Mock<ISeatValidator>();
            var mockApplicantValidator = new Mock<IApplicantValidator>();

            mockSeatValidator.Setup(x => x.Validate("YHT1","IST", new TrainSeat("1", 1), new DateTime(2020, 11, 12))).Returns(true);

            TrainReservationManager manager = new TrainReservationManager(mockSeatValidator.Object, mockApplicantValidator.Object);
            //act
            manager.MakeReservation(request);
            //assert
            Assert.That(request.IsValid, Is.True);
        }

        [Test]
        public void AcceptRequestWithMoqDependencyWithSetupForAnyParams()
        {
            //arrange
            var mockSeatValidator = new Mock<ISeatValidator>();
            var mockApplicantValidator = new Mock<IApplicantValidator>();

            mockSeatValidator.Setup(x => x.Validate(It.IsAny<string>(), It.IsAny<string>(), new TrainSeat("1", 1), new DateTime(2020, 11, 12))).Returns(true);

            TrainReservationManager manager = new TrainReservationManager(mockSeatValidator.Object, mockApplicantValidator.Object);
            //act
            manager.MakeReservation(request);
            //assert
            Assert.That(request.IsValid, Is.True);
        }

        [Test]
        public void AcceptRequestWithMoqDependencyWithSetupBothDependency()
        {
            //arrange
            var mockSeatValidator = new Mock<ISeatValidator>();
            var mockApplicantValidator = new Mock<IApplicantValidator>();

            mockSeatValidator.Setup(x => x.Validate("YHT1", "IST", new TrainSeat("1", 1), new DateTime(2020, 11, 12))).Returns(true);

            mockApplicantValidator.Setup(x => x.IsValid).Returns(true);

            TrainReservationManager manager = new TrainReservationManager(mockSeatValidator.Object, mockApplicantValidator.Object);
            //act
            manager.MakeReservation(request);
            //assert
            Assert.That(request.IsValid, Is.True);
        }
    }
}
