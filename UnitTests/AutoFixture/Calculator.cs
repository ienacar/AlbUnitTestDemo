using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.AutoFixture
{
    public class Calculator
    {

        public int Value { get; private set; }

        public void Addition(int number1)
        {
            Value += number1;
        }

        public void Subtract(int number1)
        {
            Value -= number1;
        }
    }
}
