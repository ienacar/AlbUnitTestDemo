using NunitDemoLib.Entity;
using NunitDemoLib.Message;
using System.Collections.Generic;

namespace NunitDemoLib
{
    public class ReservationManager
    {
        private const int maxDateDiff = 7;

        private const int minAge = 18;

        public List<Company> Companies { get; }

        public ReservationManager(List<Company> companies)
        {
            Companies = companies;
        }

        public ReservationResponse MakeReservation(ReservationRequest request)
        {
            ReservationResponse response = new ReservationResponse(request.Applicant,request.Location,request.Date);
            //Business controls
            if (Utils.GetDeteDiffFromTodayInDays(request.Date) > maxDateDiff)
            {
                response.Decline();
                return response;
            }

            if (request.Applicant.Age < minAge)
            {
                response.Decline();
                return response;
            }

            response.SetCompany(GetBestOffer(request.Location));
            response.Accept();
            return response;
        }

        public OfferedJourney GetBestOffer(Location location)
        {
            var companyComparer = new ReservationCompanyComparer(Companies);
            return companyComparer.GetBestOffer(location);
        }

    }
}
