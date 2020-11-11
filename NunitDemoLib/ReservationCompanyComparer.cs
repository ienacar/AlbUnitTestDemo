using NunitDemoLib.Entity;
using System.Collections.Generic;

namespace NunitDemoLib
{
    public class ReservationCompanyComparer
    {
        public List<Company> Companies { get; }

        public ReservationCompanyComparer(List<Company> companies)
        {
            Companies = companies;
        }

        public List<OfferedJourney> CompareCompanies (Location location)
        {
            var compared = new List<OfferedJourney>();

            foreach (var company in Companies)
            {
                var vehicles = company.Vehicles.FindAll(vehicle => vehicle.Location.Equals(location));

                foreach (var vehicle in vehicles)
                {
                    compared.Add(new OfferedJourney(company.Name,vehicle,vehicle.Price));
                }
            }
            return compared;
        }

        public OfferedJourney GetBestOffer ( Location location)
        {
            var comparisions = CompareCompanies(location);
            OfferedJourney BestOffer = comparisions[0];
            foreach (var company in comparisions)
            {
                if(company.Vehicle.Price < BestOffer.Vehicle.Price)
                {
                    BestOffer = company;
                }
            }
            return BestOffer;
        }
    }
}
