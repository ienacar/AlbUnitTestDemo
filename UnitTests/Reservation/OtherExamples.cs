using DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Reservation
{
    public class OtherExamples
    {
        [Category("Seat")]
        [Test]
        public void NullTest()
        {
            //arrange
            string name = "ibrahim";
            //act
            //assert
            Assert.That(name,Is.Not.Null);
        }

        [Test]
        public void StringTests()
        {
            //arrange
            string name = "ibrahim";
            //act
            //assert
            Assert.That(name,Is.Not.Empty);
            Assert.That(name, Is.EqualTo("ibrahim"));
            Assert.That(name, Is.EqualTo("ibRAhiM").IgnoreCase);

            Assert.That(name, Does.StartWith("ib"));
            Assert.That(name, Does.EndWith("him"));
            Assert.That(name, Does.Contain("ra"));

            Assert.That(name, Does.Not.Contain("xyra"));

            Assert.That(name, Does.StartWith("ib").And.EndWith("him"));
            Assert.That(name, Does.StartWith("ib").Or.Not.Contain("xyra"));
        }

        [Test]
        public void BoolTest()
        {
            //arrange
            bool flag = true;
            //assert
            Assert.That(flag);
            Assert.That(flag == true);
            Assert.That(flag, Is.True);
            Assert.That(flag, Is.Not.False);
        }

        [Test]
        public void RangeTest()
        {
            //arrange
            int x = 30;
            //assert
            Assert.That(x , Is.GreaterThan(20));
            Assert.That(x, Is.GreaterThanOrEqualTo(30));
            Assert.That(x, Is.LessThan(40));
            Assert.That(x, Is.LessThanOrEqualTo(30));


            DateTime date1 = new DateTime(2020, 11, 11);
            DateTime date2 = new DateTime(2020, 11, 13);

            Assert.That(date1, Is.EqualTo(date2).Within(3).Days);
        }

        
    }
}
