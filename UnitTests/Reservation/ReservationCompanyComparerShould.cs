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
        List<Company> Companies;
        List<OfferedJourney> ComparedCompanies;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            //arrange
            Companies = new List<Company>
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
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            //clean data
        }

        [SetUp]
        public void Setup()
        {
            //arrange
            var comparer = new ReservationCompanyComparer(Companies);
            //act
            ComparedCompanies = comparer.CompareCompanies(new Location("IST", "ANK"));
        }

        [TearDown]
        public void TearDown()
        {
            //reset data;
        }

        [Test]
        public void ReturnNumberOfCompanyComparison()
        {
            //assert
            Assert.That(ComparedCompanies, Has.Exactly(3).Items);
        }

        [Test]
        public void ReturnContainsCompanyComparison()
        {
            //arrange
            var expectedCompany = new OfferedJourney("C3", new Vehicle("V1", new Location("IST", "ANK"), new TimeSpan(10, 00, 00), 100),100);

            //assert
            Assert.That(ComparedCompanies, Does.Contain(expectedCompany));
        }

        [Test]
        public void ReturnPartialCompanyComparison()
        {
            //assert
            Assert.That(ComparedCompanies, Has.Exactly(1)
                                            .Property("Name").EqualTo("C1")
                                            .And
                                            .Property("Vehicle").Property("Price").LessThanOrEqualTo(80));
        }

        [Test]
        public void ReturnPartialStrongTypeCompanyComparison()
        {
            //assert
            Assert.That(ComparedCompanies, Has.Exactly(1)
                                            .Matches<OfferedJourney> (company => company.Name == "C1" 
                                                                                && company.Vehicle.Price == 80));
        }

        [Test]
        public void ReturnNumberOfCompanyComparisonCustomConstraint()
        {
            //assert
            Assert.That(ComparedCompanies, Has.Exactly(3).Items
                                            .Matches(new OfferedJourneyLocationConstaint(new Location("IST", "ANK"))));
        }

    }
}
