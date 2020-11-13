using AutoFixture;
using NUnit.Framework;
using NunitDemoLib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.AutoFixture
{
    public class AutoFixtureDemos
    {
        [Test]
        public void TestCalculator()
        {
            //arrange
            var calc = new Calculator();
            var fixture = new Fixture();
            var number = fixture.Create<int>();
            //act
            calc.Addition(number);
            //assert
            Assert.That(calc.Value,Is.GreaterThan(0));
        }

        [Test]
        public void NumberGenerators()
        {
            var fixture = new Fixture();
            var decimalNumber = fixture.Create<decimal>();
            var longNumber = fixture.Create<long>();
        }

        [Test]
        public void TestNameJoiner()
        {
            //arrange
            var joiner = new NameJoiner();
            var fixture = new Fixture();

            var firstName = fixture.Create<string>("FirstName_");
            var lastName = fixture.Create<string>("LastName_");
            //act

            joiner.JoinName(firstName, lastName);
            //assert
            Assert.That(joiner.FullName, Is.EqualTo(firstName + ' ' + lastName));
        }

        [Test]
        public void DateTimeGenerators()
        {
            var fixture = new Fixture();
            var dateTime = fixture.Create<DateTime>();
            var timeSpan = fixture.Create<TimeSpan>();

        }

        [Test]
        public void GuidGenerator()
        {
            var fixture = new Fixture();
            var guidCreated = fixture.Create<Guid>();
        }

        [Test]
        public void EnumGenerator()
        {
            var fixture = new Fixture();

            var enum1 = fixture.Create<Status>();
            var enum2 = fixture.Create<Status>();
        }

        enum Status
        {
            idle,
            active,
            passive
        }

        [Test]
        public void CollectionGenerator()
        {
            var fixture = new Fixture();

            var stringList1 = fixture.CreateMany<string>();
            var stringList2 = fixture.CreateMany<string>(10);
        }

        [Test]
        public void CollectionGeneratorInjectObject()
        {
            //arrange
            var joiner = new NameJoiner();
            var fixture = new Fixture();

            //act
            fixture.AddManyTo(joiner.Names,10);
            joiner.CountNames();
            //assert
            Assert.That(joiner.count, Is.EqualTo(10));
        }

        [Ignore("rand gen creator demo")]
        [Test]
        public void CollectionGeneratorInjectObjectWithCreator()
        {
            //arrange
            var joiner = new NameJoiner();
            var fixture = new Fixture();

            //act
            fixture.AddManyTo(joiner.Names, () => { return new Random().Next().ToString(); });
            joiner.CountNames();
            //assert
            Assert.That(joiner.count, Is.EqualTo(10));
        }

        [Test]
        public void ApplicantAutofixture()
        {
            var fixture = new Fixture();
            fixture.Inject<string>("11111111111");
            var applicant = fixture.Create<Applicant>();
        }

        [Test]
        public void ApplicantAutofixtureWithObjectFullProp()
        {
            var fixture = new Fixture();
            fixture.Inject(new Applicant("ibrahim", "11111111111", 19));
            var applicant1 = fixture.Create<Applicant>();
            var applicant2 = fixture.Create<Applicant>();
        }

        [Test]
        public void ApplicantAutofixtureWithGenerator()
        {
            var fixture = new Fixture();
            fixture.Inject<string>(DumyStringGenerator());
            var applicant = fixture.Create<Applicant>();
        }

        private string DumyStringGenerator()
        {
            return "11111111112";
        }
    }
}
