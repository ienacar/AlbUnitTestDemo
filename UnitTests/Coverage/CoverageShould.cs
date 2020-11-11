using Covarage;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Coverage
{
    public class CoverageShould
    {
        [Test]
        public void CalculatorShould()
        {
            //arrange
            int number1 = 1;
            int number2 = -1;
            int expectedNumber = 0;
            //act
            var sum = Calculator.Addition(number1,number2);
            //assert
            Assert.That(sum,Is.EqualTo(expectedNumber));
        }

        [Test]
        public void ReturnPositiveAddition()
        {
            //arrange
            int number1 = 1;
            int number2 = 1;
            int expectedNumber = 2;
            //act
            var sum = Calculator.PositiveAddition(number1,number2);
            //assert
            Assert.That(sum, Is.EqualTo(expectedNumber));
        }

        [Test]
        public void ReturnPositiveAddition_WithException()
        {
            //arrange
            int number1 = -1;
            int number2 = 1;
            int expectedNumber = 0;
            //act
            //assert
            Assert.That(() => Calculator.PositiveAddition(number1, number2), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        //[Test]
        //public void ReturnPositiveAddition_WithExceptionV2()
        //{
        //    //arrange
        //    int number1 = -1;
        //    int number2 = 1;
        //    int expectedNumber = 0;
        //    //act
        //    try
        //    {
        //        Calculator.PositiveAddition(number1, number2);
        //    }
        //    catch (ArgumentOutOfRangeException ex)
        //    {
        //        //assert
        //        Assert.That(ex, Throws.TypeOf<ArgumentOutOfRangeException>());
        //    }

        //}
    }
}
