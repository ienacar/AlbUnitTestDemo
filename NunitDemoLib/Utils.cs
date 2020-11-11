using System;

namespace NunitDemoLib
{
    public class Utils
    {
        public static double GetDeteDiffFromTodayInDays(DateTime date)
        {
            return (date - DateTime.Today).TotalDays;
        }
    }
}
