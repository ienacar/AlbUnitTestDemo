using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitDemoLib.Entity
{
    public class Applicant
    {
        public string Name { get; private set; }
        public string TCKN { get; private set; }
        public int Age { get; private set; }

        public Applicant(string name, string tckn, int age)
        {
            Name = name;
            TCKN = tckn;
            Age = age;
        }
    }
}
