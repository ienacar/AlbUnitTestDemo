using NUnit.Framework;
using NunitDemoLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Reservation
{
    public class ReservationTicketPriceCalculatorShould
    {
        [Test]
        public void ReturnOneTermPrice()
        {
            //arrange
            var calculator = new ReservationTicketPriceCalculator();
            //act
            var payment = calculator.CalculateTicketPrice(100,1,0.02M);
            //assert
            Assert.That(payment, Is.EqualTo(102));
        }

        [Test]
        public void ReturnMultiTermPrice()
        {
            //arrange
            var calculator = new ReservationTicketPriceCalculator();
            //act
            var payment = calculator.CalculateTicketPrice(100, 10, 0.02M);
            //assert
            Assert.That(payment, Is.EqualTo(10.2));
        }

        [Test]
        public void ReturnMultiTermPriceWithRatev2()
        {
            //arrange
            var calculator = new ReservationTicketPriceCalculator();
            //act
            var payment = calculator.CalculateTicketPrice(100, 10, 0.03M);
            //assert
            Assert.That(payment, Is.EqualTo(10.3));
        }

        [Test]
        [TestCase(100,1,0.02,ExpectedResult = 102)]
        [TestCase(100, 10, 0.02, ExpectedResult = 10.2)]
        [TestCase(100, 10, 0.03, ExpectedResult = 10.3)]
        public decimal ReturnPriceWithMultiCases(decimal price,int term, decimal rate)
        {
            //arrange
            var calculator = new ReservationTicketPriceCalculator();
            //act
            return calculator.CalculateTicketPrice(price, term, rate);
        }

        [Test]
        [TestCaseSource(typeof(TicketPriceData), "TestCases")]
        public void ReturnPriceWithMultiCases_FromClass(decimal price, int term, decimal rate,decimal expectedValue)
        {
            //arrange
            var calculator = new ReservationTicketPriceCalculator();
            //act
            var payment = calculator.CalculateTicketPrice(price, term, rate);
            //
            Assert.That(payment,Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCaseSource(typeof(TicketPriceData), "TestCasesWithReturn")]
        public decimal ReturnPriceWithMultiCases_FromClassWithReturnValues(decimal price, int term, decimal rate)
        {
            //arrange
            var calculator = new ReservationTicketPriceCalculator();
            //act
            return calculator.CalculateTicketPrice(price, term, rate);
        }

        [Test]
        [TestCaseSource(typeof(TicketPriceData), "CasesFromCsvFile",new object[] { @"D:\Workspace\AlbUnitTestDemo\UnitTests\Reservation\Data.csv" })]
        public void ReturnPriceWithMultiCases_FromCsvFile(decimal price, int term, decimal rate, decimal expectedValue)
        {
            //arrange
            var calculator = new ReservationTicketPriceCalculator();
            //act
            var payment = calculator.CalculateTicketPrice(price, term, rate);
            //assert
            Assert.That(payment, Is.EqualTo(expectedValue));
        }

    }
}
