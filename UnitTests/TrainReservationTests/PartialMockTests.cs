using Moq;
using Moq.Protected;
using NUnit.Framework;
using NunitDemoLib.Entity;
using ReservationLib;
using ReservationLib.Entity;
using ReservationLib.Services;
using System;

namespace UnitTests.TrainReservationTests
{
    public class PartialMockTests
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

        //[Ignore("protected callservice")]
        //[Test]
        //public void PartialObjectTest()
        //{
        //    //arrange
        //    var mockSeatValidator = new Mock<SeatValidatorWebServiceGateway>();

        //    var mockApplicantValidator = new Mock<IApplicantValidator>();

        //    //mockSeatValidator.Setup(x => x.Validate("YHT1", "IST", new TrainSeat("1", 1), new DateTime(2020, 11, 12))).Returns(true);
        //    mockSeatValidator.Setup(x => x.CallService("YHT1", "IST", new TrainSeat("1", 1), new DateTime(2020, 11, 12))).Returns(true);

        //    mockApplicantValidator.Setup(x => x.ValidateResult.IsValid).Returns(true);

        //    TrainReservationManager manager = new TrainReservationManager(mockSeatValidator.Object, mockApplicantValidator.Object);
        //    //act
        //    manager.MakeReservation(request);
        //    //assert
        //    Assert.That(request.IsValid, Is.True);
        //}

        //[Ignore("protected callservice")]
        //[Test]
        //public void PartialObjectTestCheckDatetime()
        //{
        //    //arrange
        //    var mockSeatValidator = new Mock<SeatValidatorWebServiceGateway>();

        //    var mockApplicantValidator = new Mock<IApplicantValidator>();

        //    //mockSeatValidator.Setup(x => x.Validate("YHT1", "IST", new TrainSeat("1", 1), new DateTime(2020, 11, 12))).Returns(true);
        //    mockSeatValidator.Setup(x => x.CallService("YHT1", "IST", new TrainSeat("1", 1), new DateTime(2020, 11, 12))).Returns(true);

        //    mockApplicantValidator.Setup(x => x.ValidateResult.IsValid).Returns(true);

        //    TrainReservationManager manager = new TrainReservationManager(mockSeatValidator.Object, mockApplicantValidator.Object);
        //    //act
        //    manager.MakeReservation(request);
        //    //assert
        //    Assert.That(request.IsValid, Is.True);
        //    Assert.That(mockSeatValidator.Object.LastCheckTime, Is.EqualTo(DateTime.Now).Within(1).Seconds);
        //}

        //[Ignore("protected callservice")]
        //[Test]
        //public void PartialObjectTestCheckDatetimeWithDeterministicValue()
        //{
        //    //arrange
        //    var mockSeatValidator = new Mock<SeatValidatorWebServiceGateway>();

        //    var mockApplicantValidator = new Mock<IApplicantValidator>();

        //    //mockSeatValidator.Setup(x => x.Validate("YHT1", "IST", new TrainSeat("1", 1), new DateTime(2020, 11, 12))).Returns(true);
        //    mockSeatValidator.Setup(x => x.CallService("YHT1", "IST", new TrainSeat("1", 1), new DateTime(2020, 11, 12))).Returns(true);

        //    var expectedDatetime = new DateTime(2020, 11, 12);
        //    mockSeatValidator.Setup(x => x.GetDatetimeNow()).Returns(expectedDatetime);

        //    mockApplicantValidator.Setup(x => x.ValidateResult.IsValid).Returns(true);

        //    TrainReservationManager manager = new TrainReservationManager(mockSeatValidator.Object, mockApplicantValidator.Object);
        //    //act
        //    manager.MakeReservation(request);
        //    //assert
        //    Assert.That(request.IsValid, Is.True);
        //    Assert.That(mockSeatValidator.Object.LastCheckTime, Is.EqualTo(expectedDatetime));
        //}

        [Test]
        public void PartialObjectTestCheckDatetimeWithDeterministicValue()
        {
            //arrange
            var mockSeatValidator = new Mock<SeatValidatorWebServiceGateway>();

            var mockApplicantValidator = new Mock<IApplicantValidator>();

            //mockSeatValidator.Setup(x => x.Validate("YHT1", "IST", new TrainSeat("1", 1), new DateTime(2020, 11, 12))).Returns(true);
            mockSeatValidator.Protected().Setup<bool>("CallService", "YHT1", "IST", new TrainSeat("1", 1), new DateTime(2020, 11, 12)).Returns(true);

            var expectedDatetime = new DateTime(2020, 11, 12);
            mockSeatValidator.Setup(x => x.GetDatetimeNow()).Returns(expectedDatetime);

            mockApplicantValidator.Setup(x => x.ValidateResult.IsValid).Returns(true);

            TrainReservationManager manager = new TrainReservationManager(mockSeatValidator.Object, mockApplicantValidator.Object);
            //act
            manager.MakeReservation(request);
            //assert
            Assert.That(request.IsValid, Is.True);
            Assert.That(mockSeatValidator.Object.LastCheckTime, Is.EqualTo(expectedDatetime));
        }

        public interface ISeatValidatorWebServiceGateway
        {
            bool CallService(string vehicleId, string country, Seat seat, DateTime date, bool flag);
        }

        [Test]
        public void PartialObjectTestCheckDatetimeWithDeterministicValueWithIntellisens()
        {
            //arrange
            var mockSeatValidator = new Mock<SeatValidatorWebServiceGateway>();

            var mockApplicantValidator = new Mock<IApplicantValidator>();

            //mockSeatValidator.Setup(x => x.Validate("YHT1", "IST", new TrainSeat("1", 1), new DateTime(2020, 11, 12))).Returns(true);
            mockSeatValidator.Protected()
                .As<ISeatValidatorWebServiceGateway>()
                    .Setup(x => x.CallService("YHT1", "IST", new TrainSeat("1", 1), new DateTime(2020, 11, 12),true)).Returns(true);

            var expectedDatetime = new DateTime(2020, 11, 12);
            mockSeatValidator.Setup(x => x.GetDatetimeNow()).Returns(expectedDatetime);

            mockApplicantValidator.Setup(x => x.ValidateResult.IsValid).Returns(true);

            TrainReservationManager manager = new TrainReservationManager(mockSeatValidator.Object, mockApplicantValidator.Object);
            //act
            manager.MakeReservation(request);
            //assert
            Assert.That(request.IsValid, Is.True);
            Assert.That(mockSeatValidator.Object.LastCheckTime, Is.EqualTo(expectedDatetime));
        }
    }
}
