using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covarage
{
    public class Calculator
    {
        public static int Addition(int number1, int number2)
        {
            return number1 + number2;
        }

        public static int PositiveAddition(int number1, int number2)
        {
            if (number1 < 0 || number2 < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return Addition(number1, number2);
        }

    }
}
