using NUnit.Framework;
using NunitDemoLib;
using NunitDemoLib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Reservation
{
    public class ReservationCompanyComparerShould
    {
        [Test]
        public void ReturnNumberOfCompanyComparison()
        {
            //arrange
            List<Company> Companies = new List<Company>
            {
                new Company("C1", new List<Vehicle> {
                                        new Vehicle("V1",new Location("IST","ANK"),new TimeSpan(10,00,00),80),
                                        new Vehicle("V1",new Location("IST","IZM"),new TimeSpan(10,00,00),100)
                                    }
                ),
                new Company("C2", new List<Vehicle> {
                                        new Vehicle("V1",new Location("IST","ANK"),new TimeSpan(10,00,00),90),
                                        new Vehicle("V1",new Location("IST","IZM"),new TimeSpan(11,00,00),120)
                                    }
                ),
                new Company("C3", new List<Vehicle> {
                                        new Vehicle("V1",new Location("IST","ANK"),new TimeSpan(10,00,00),100)
                                    }
                )
            };
            var comparer = new ReservationCompanyComparer(Companies);
            //act
            var ComparedCompanies = comparer.CompareCompanies(new Location("IST","ANK"));
            //assert
            Assert.That(ComparedCompanies, Has.Exactly(3).Items);
        }

        [Test]
        public void ReturnContainsCompanyComparison()
        {
            //arrange
            List<Company> Companies = new List<Company>
            {
                new Company("C1", new List<Vehicle> {
                                        new Vehicle("V1",new Location("IST","ANK"),new TimeSpan(10,00,00),80),
                                        new Vehicle("V1",new Location("IST","IZM"),new TimeSpan(10,00,00),100)
                                    }
                ),
                new Company("C2", new List<Vehicle> {
                                        new Vehicle("V1",new Location("IST","ANK"),new TimeSpan(10,00,00),90),
                                        new Vehicle("V1",new Location("IST","IZM"),new TimeSpan(11,00,00),120)
                                    }
                ),
                new Company("C3", new List<Vehicle> {
                                        new Vehicle("V1",new Location("IST","ANK"),new TimeSpan(10,00,00),100)
                                    }
                )
            };
            var comparer = new ReservationCompanyComparer(Companies);
            var expectedCompany = new OfferedJourney("C3", new Vehicle("V1", new Location("IST", "ANK"), new TimeSpan(10, 00, 00), 100),100);
            //act
            var ComparedCompanies = comparer.CompareCompanies(new Location("IST", "ANK"));
            //assert
            Assert.That(ComparedCompanies, Does.Contain(expectedCompany));
        }

        [Test]
        public void ReturnPartialCompanyComparison()
        {
            //arrange
            List<Company> Companies = new List<Company>
            {
                new Company("C1", new List<Vehicle> {
                                        new Vehicle("V1",new Location("IST","ANK"),new TimeSpan(10,00,00),80),
                                        new Vehicle("V1",new Location("IST","IZM"),new TimeSpan(10,00,00),100)
                                    }
                ),
                new Company("C2", new List<Vehicle> {
                                        new Vehicle("V1",new Location("IST","ANK"),new TimeSpan(10,00,00),90),
                                        new Vehicle("V1",new Location("IST","IZM"),new TimeSpan(11,00,00),120)
                                    }
                ),
                new Company("C3", new List<Vehicle> {
                                        new Vehicle("V1",new Location("IST","ANK"),new TimeSpan(10,00,00),100)
                                    }
                )
            };
            var comparer = new ReservationCompanyComparer(Companies);
            
            //act
            var ComparedCompanies = comparer.CompareCompanies(new Location("IST", "ANK"));
            //assert
            Assert.That(ComparedCompanies, Has.Exactly(1)
                                            .Property("Name").EqualTo("C1")
                                            .And
                                            .Property("Vehicle").Property("Price").LessThanOrEqualTo(80));
        }

        [Test]
        public void ReturnPartialStrongTypeCompanyComparison()
        {
            //arrange
            List<Company> Companies = new List<Company>
            {
                new Company("C1", new List<Vehicle> {
                                        new Vehicle("V1",new Location("IST","ANK"),new TimeSpan(10,00,00),80),
                                        new Vehicle("V1",new Location("IST","IZM"),new TimeSpan(10,00,00),100)
                                    }
                ),
                new Company("C2", new List<Vehicle> {
                                        new Vehicle("V1",new Location("IST","ANK"),new TimeSpan(10,00,00),90),
                                        new Vehicle("V1",new Location("IST","IZM"),new TimeSpan(11,00,00),120)
                                    }
                ),
                new Company("C3", new List<Vehicle> {
                                        new Vehicle("V1",new Location("IST","ANK"),new TimeSpan(10,00,00),100)
                                    }
                )
            };
            var comparer = new ReservationCompanyComparer(Companies);

            //act
            var ComparedCompanies = comparer.CompareCompanies(new Location("IST", "ANK"));
            //assert
            Assert.That(ComparedCompanies, Has.Exactly(1)
                                            .Matches<OfferedJourney> (company => company.Name == "C1" 
                                                                                && company.Vehicle.Price == 80));
        }

    }
}
