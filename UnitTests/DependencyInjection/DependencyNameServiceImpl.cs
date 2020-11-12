using DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.DependencyInjection
{
    public class DependencyNameServiceImpl : IDependencyNameService
    {
        private string name;

        public DependencyNameServiceImpl (string InjectionName)
        {
            name = InjectionName;
        }
        public string GetName()
        {
            return name;
        }
    }
}
