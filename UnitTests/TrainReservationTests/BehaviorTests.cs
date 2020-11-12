using Moq;
using NUnit.Framework;
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
    public class BehaviorTests
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

        delegate void ValidateCallback(string vehicleId, string country, Seat seats, DateTime date, ref VerificationStatus status);

        [Test]
        public void VerifySeatValidatorInitializeCalled()
        {
            //arrange
            var mockSeatValidator = new Mock<ISeatValidator>();
            var mockApplicantValidator = new Mock<IApplicantValidator>();
            //var mockValidateResult = new Mock<ValidateResult>();

            mockSeatValidator.Setup(x => x.Validate("YHT1", "IST", new TrainSeat("1", 1), new DateTime(2020, 11, 12), ref It.Ref<VerificationStatus>.IsAny))
                                    .Callback(
                                        new ValidateCallback(
                                            (string vehicleId, string country, Seat seats, DateTime date, ref VerificationStatus status) => status = new VerificationStatus(true))

                );


            //mockValidateResult.Setup(x => x.IsValid).Returns(true);
            //mockApplicantValidator.Setup(x => x.ValidateResult).Returns(mockValidateResult.Object);

            mockApplicantValidator.SetupAllProperties();
            mockApplicantValidator.Setup(x => x.ValidateResult.IsValid).Returns(true);

            TrainReservationManager manager = new TrainReservationManager(mockSeatValidator.Object, mockApplicantValidator.Object);
            //act
            manager.MakeReservation(request);

            //assert
            mockSeatValidator.Verify(x => x.Initialize(),Times.Once);
        }


        [Test]
        public void VerifyApplicantValidatorValidateCalled()
        {
            //arrange
            var mockSeatValidator = new Mock<ISeatValidator>();
            var mockApplicantValidator = new Mock<IApplicantValidator>();
            //var mockValidateResult = new Mock<ValidateResult>();

            mockSeatValidator.Setup(x => x.Validate("YHT1", "IST", new TrainSeat("1", 1), new DateTime(2020, 11, 12), ref It.Ref<VerificationStatus>.IsAny))
                                    .Callback(
                                        new ValidateCallback(
                                            (string vehicleId, string country, Seat seats, DateTime date, ref VerificationStatus status) => status = new VerificationStatus(true))

                );


            //mockValidateResult.Setup(x => x.IsValid).Returns(true);
            //mockApplicantValidator.Setup(x => x.ValidateResult).Returns(mockValidateResult.Object);

            mockApplicantValidator.SetupAllProperties();
            mockApplicantValidator.Setup(x => x.ValidateResult.IsValid).Returns(true);

            TrainReservationManager manager = new TrainReservationManager(mockSeatValidator.Object, mockApplicantValidator.Object);
            //act
            manager.MakeReservation(request);

            //assert
            mockApplicantValidator.Verify(x => x.Validate(It.IsAny<string>(), It.IsAny<string>()));
        }

        [Test]
        public void VerifyApplicantValidatorCountPropertyTests()
        {
            //arrange
            var mockSeatValidator = new Mock<ISeatValidator>();
            var mockApplicantValidator = new Mock<IApplicantValidator>();
            //var mockValidateResult = new Mock<ValidateResult>();

            mockSeatValidator.Setup(x => x.Validate("YHT1", "IST", new TrainSeat("1", 1), new DateTime(2020, 11, 12), ref It.Ref<VerificationStatus>.IsAny))
                                    .Callback(
                                        new ValidateCallback(
                                            (string vehicleId, string country, Seat seats, DateTime date, ref VerificationStatus status) => status = new VerificationStatus(true))

                );


            //mockValidateResult.Setup(x => x.IsValid).Returns(true);
            //mockApplicantValidator.Setup(x => x.ValidateResult).Returns(mockValidateResult.Object);

            mockApplicantValidator.SetupAllProperties();
            mockApplicantValidator.Setup(x => x.ValidateResult.IsValid).Returns(true);

            TrainReservationManager manager = new TrainReservationManager(mockSeatValidator.Object, mockApplicantValidator.Object);
            //act
            manager.MakeReservation(request);

            //assert
            mockApplicantValidator.VerifyGet(x => x.Count, Times.Once);
            mockApplicantValidator.VerifySet(x => x.Count = It.IsAny<int>());
        }
    }
}
