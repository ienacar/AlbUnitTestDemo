using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.AutoFixture
{
    public class NameJoiner
    {
        public List<string> Names { get; set; } = new List<string>();

        public int count { get; private set; }

        public void CountNames()
        {
            foreach (var name in Names)
            {
                count++;
            }
        }
        public string FullName { get; set; }

        public void JoinName(string firstName, string lastName)
        {
            FullName = firstName + ' ' + lastName;
        }
    }
}
