using AutoFixture;
using NUnit.Framework;
using NunitDemoLib.Entity;
using System;
using System.Collections.Generic;
using AutoFixture.NUnit3;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.AutoMoq;
using DependencyInjection;
using Moq;

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

        [Test]
        public void ApplicantAutofixtureWithGeneratorCheckGeneratedValue()
        {
            //arrange
            var fixture = new Fixture();

            //int age = fixture.Create<int>();
            //fixture.Inject(age);
            var age = fixture.Freeze<int>();

            fixture.Inject<string>(DumyStringGenerator());
            var applicant = fixture.Create<Applicant>();

            //assert
            Assert.That(applicant.Age,Is.EqualTo(age));
        }

        [Test]
        public void CreteObjectWithExceptionProp()
        {
            var fixture = new Fixture();

            var applicant = fixture.Build<Applicant>()
                                    .Without(x => x.TCKN)
                                    .Create();
        }

        [Test]
        public void OmitObjectFixture()
        {
            var fixture = new Fixture();

            var applicant = fixture.Build<Applicant>()
                                    .OmitAutoProperties()
                                    .Create();
        }


        [Test]
        public void CreteObjectWithCustomProp()
        {
            var fixture = new Fixture();

            var applicant = fixture.Build<Applicant>()
                                    .With(x => x.TCKN, DumyStringGenerator)
                                    .Create();
        }

        [Test]
        public void OmitObjectFixtureAddSingleProp()
        {
            var fixture = new Fixture();

            var applicant = fixture.Build<Applicant>()
                                    .OmitAutoProperties()
                                    .With(x => x.TCKN, DumyStringGenerator)
                                    .Create();
        }

        [Test]
        public void NestedObjectFixtureDemo()
        {
            var fixture = new Fixture();
            var company = fixture.Create<Company>();
        }

        [Test]
        public void NestedObjectFixtureDemoCustomProperties()
        {
            var fixture = new Fixture();

            var vehicle1 = fixture.Build<Vehicle>()
                                    .With(x => x.VehicleId, "v1")
                                    .Create();

            var vehicle2 = fixture.Build<Vehicle>()
                                    .With(x => x.VehicleId, "v2")
                                    .Without(x => x.Price)
                                    .Do(x => x.Price = 100)
                                    .Create();

            var company1 = fixture.Build<Company>().Create();

            var company2 = fixture.Build<Company>()
                                    .Without(x => x.Vehicles)
                                    .Do(x => x.Vehicles = new List<Vehicle>())
                                    .Do(x => x.Vehicles.Add(vehicle1))
                                    .Do(x => x.Vehicles.Add(vehicle2))
                                    .Create();
        }

        [Test]
        public void CustomDatetime()
        {
            var fixture = new Fixture();
            //fixture.Customize(new CurrentDateTimeCustomization());
            fixture.Customizations.Add(new CurrentDateTimeGenerator());

            var datetime = fixture.Create<DateTime>();
        }

        [Test]
        public void ApplicantAutofixtureWithCustomTcknGenertor()
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new TcknProperyGenerator());
            var applicant = fixture.Create<Applicant>();
        }

        [Test]
        [TestCase(1,2)]
        [TestCase(1, 0)]
        [TestCase(-1,1)]
        public void DataDrivenCalculator(int num1,int num2)
        {
            //arrange
            var calculator = new Calculator();
            //act
            calculator.Addition(num1);
            calculator.Addition(num2);
            //assert
            Assert.That(calculator.Value,Is.EqualTo(num1+num2));
        }

        [Test]
        [InlineAutoData]
        [InlineAutoData(0)]
        [InlineAutoData(-1)]
        public void DataDrivenCalculatorWithAutofixture(int num1, int num2)
        {
            //arrange
            var calculator = new Calculator();
            //act
            calculator.Addition(num1);
            calculator.Addition(num2);
            //assert
            Assert.That(calculator.Value, Is.EqualTo(num1 + num2));
        }

        [Test]
        [AutoData]
        public void DataDrivenCalculatorWithAutofixtureVersion2(int num1, int num2)
        {
            //arrange
            var calculator = new Calculator();
            //act
            calculator.Addition(num1);
            calculator.Addition(num2);
            //assert
            Assert.That(calculator.Value, Is.EqualTo(num1 + num2));
        }

        [Test]
        [AutoData]
        public void DataDrivenCalculatorWithAutofixtureVersion3(int num1, int num2,Calculator calc)
        {

            //act
            calc.Addition(num1);
            calc.Addition(num2);
            //assert
            Assert.That(calc.Value, Is.EqualTo(num1 + num2));
        }

        [Test]
        public void AutoMoqFixture()
        {
            //arrange
            var fixture = new Fixture();

            fixture.Customize(new AutoMoqCustomization());
            var nameService = fixture.Freeze<Mock<IDependencyNameService>>();

            var sut = fixture.Create<ConstructorInjection>();
            //act
            sut.SayHello();
            //assert
            nameService.Verify(x => x.GetName(), Times.Once);
        }
    }
}
