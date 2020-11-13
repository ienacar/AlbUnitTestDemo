using System;

namespace UnitTests.TddTests
{
    public class FizzBuzzManager
    {
        public FizzBuzzManager()
        {
        }

        public string Print(int v)
        {
            if (IsFizz(v) && IsBuzz(v))
            {
                return "FizzBuzz";
            }
            else if (IsFizz(v))
            {
                return "Fizz";
            }
            else if(IsBuzz(v))
            {
                return "Buzz";
            }
            return v.ToString();
        }

        private bool IsFizz(int val)
        {
            if (val % 3 == 0) return true;
            return false;
        }

        private bool IsBuzz(int val)
        {
            if (val % 5 == 0) return true;
            return false;
        }
    }
}