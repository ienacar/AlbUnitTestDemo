using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.TddTests
{
    public class FizzBuzzManagerShould
    {
        [Test]
        public void PrintNumber()
        {
            //arrange
            var fizzBuzzManager = new FizzBuzzManager();
            //act
            var returnValue = fizzBuzzManager.Print(1);
            //assert
            Assert.That(returnValue,Is.EqualTo("1"));
        }

        [Test]
        [TestCase(3,ExpectedResult = "Fizz")]
        [TestCase(6, ExpectedResult = "Fizz")]
        public string PrintFizz(int val)
        {
            //arrange
            var fizzBuzzManager = new FizzBuzzManager();
            //act
            return fizzBuzzManager.Print(val);
        }

        [Test]
        [TestCase(5, ExpectedResult = "Buzz")]
        [TestCase(10, ExpectedResult = "Buzz")]
        public string PrintBuzz(int val)
        {
            //arrange
            var fizzBuzzManager = new FizzBuzzManager();
            //act
            return fizzBuzzManager.Print(val);
        }

        [Test]
        [TestCase(15, ExpectedResult = "FizzBuzz")]
        public string PrintFizzBuzz(int val)
        {
            //arrange
            var fizzBuzzManager = new FizzBuzzManager();
            //act
            return fizzBuzzManager.Print(val);
        }

    }
}
