using NUnit.Framework;
using FluentAssertions;
using FluentAssertions.Extensions;
using System;
using NunitDemoLib.Entity;
using DependencyInjection;

namespace UnitTests.FluentAssertDemos
{
    public class Demos
    {
        [Test]
        public void StringTests()
        {
            //arrange
            string name = "ibrahim";
            //act
            //assert
            name.Should().Be("ibrahim");
            name.Should().BeEquivalentTo("iBRahim");
            name.Should().StartWith("ib");
            name.Should().EndWith("him");
            name.Should().Contain("ra");
            name.Should().BeOneOf("ibrahim", "ethem", "nacar");
            name.Should().Match("*ra*");
        }

        [Test]
        public void FloatingPointTest()
        {
            double val = 1.0 / 3.0;
            val.Should().BeApproximately(0.33, 0.04);
        }

        [Test]
        public void DateTests()
        {
            DateTime date = new DateTime(2020, 11, 13);

            date.Should().Be(13.November(2020));
            date.Should().HaveYear(2020);
            date.Should().Be(1.Days().Before(14.November(2020)));
        }

        [Test]
        public void ReturnInvalidSeatNumber()
        {
            //Assert.That(() => new Seat(0), Throws.TypeOf<ArgumentOutOfRangeException>());

            //Assert.That(() => new Seat(0)
            //            , Throws.TypeOf<ArgumentOutOfRangeException>()
            //            .With
            //            .Property("Message")
            //            .EqualTo($"Please select a seat number between 1 and 21\r\nParameter name: seatNumber")
            //           );

            //Assert.That(() => new Seat(0)
            //            , Throws.TypeOf<ArgumentOutOfRangeException>()
            //            .With
            //            .Property("ParamName")
            //            .EqualTo($"seatNumber")
            //           );

            //Assert.That(() => new Seat(0)
            //            , Throws.TypeOf<ArgumentOutOfRangeException>()
            //            .With
            //            .Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "seatNumber")
            //           );

            Action act = () => new Seat(0);
            act.Should().Throw<ArgumentOutOfRangeException>();

            act.Should().Throw<ArgumentOutOfRangeException>()
                            .And
                            .ParamName.Should().Be("seatNumber");
        }

        [Test]
        public void ArchitectoralTests()
        {
            typeof(InterfaceInjection).Should().Implement<IDependencyNameServiceInjector>();
        }
    }
}
