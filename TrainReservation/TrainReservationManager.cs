using ReservationLib.Entity;
using ReservationLib.Services;
using System;

namespace ReservationLib
{
    public class TrainReservationManager
    {
        private const int maxDateDiff = 14;

        private const int minAge = 18;

        private readonly ISeatValidator _seatvalidator;

        private readonly IApplicantValidator _applicantValidator;
        
        public TrainReservationManager(ISeatValidator seatvalidator, IApplicantValidator applicantValidator)
        {
            _seatvalidator = seatvalidator; //?? throw new ArgumentNullException(nameof(seatvalidator));
            _applicantValidator = applicantValidator;// ?? throw new ArgumentNullException(nameof(applicantValidator));
        }

        public TrainReservation MakeReservation(TrainReservation request)
        {
            //Business controls
            if((request.Date - DateTime.Today).TotalDays > maxDateDiff)
            {
                request.Decline();
                return request;
            }

            if (request.Applicant.Age < minAge)
            {
                request.Decline();
                return request;
            }

            _seatvalidator.Initialize();

            var isValidReservation = _seatvalidator.Validate(request.Train.VehicleId,request.Location.From,request.Train.Seat,request.Date);


            if (!isValidReservation)
            {
                request.Decline();
                return request;
            }

            try
            {
                _applicantValidator.Validate(request.Applicant.Name, request.Applicant.TCKN);
            }
            catch
            {
                request.Decline();
                return request;
            }

            if (!_applicantValidator.IsValid)
            {
                request.Decline();
                return request;
            }


            request.Accept();
            return request;
        }
    }
}
