using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Reservation
{
    public class TicketPriceData
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(100m, 1, 0.02m, 102m);
                yield return new TestCaseData(100m, 10, 0.02m, 10.2m);
                yield return new TestCaseData(100m, 10, 0.03m, 10.3m);
                yield return new TestCaseData(100m, 1, 0.03m, 103m);
            }
        }

        public static IEnumerable TestCasesWithReturn
        {
            get
            {
                yield return new TestCaseData(100m, 1, 0.02m).Returns(102m);
                yield return new TestCaseData(100m, 10, 0.02m).Returns(10.2m);
                yield return new TestCaseData(100m, 10, 0.03m).Returns(10.3m);
                yield return new TestCaseData(100m, 1, 0.03m).Returns(103m);
            }
        }

        public static IEnumerable CasesFromCsvFile(string csvFile)
        {
            var csvLines = File.ReadAllLines(csvFile);
            var testCases = new List<TestCaseData>();

            foreach (var line in csvLines)
            {
                string[] values = line.Replace(" ", "").Split('-');
                decimal price = decimal.Parse(values[0]);
                int term = int.Parse(values[1]);
                decimal rate = decimal.Parse(values[2]);
                decimal expectedValue = decimal.Parse(values[3]);

                testCases.Add(new TestCaseData(price,term,rate,expectedValue));
            }

            return testCases;
        }
    }
}
