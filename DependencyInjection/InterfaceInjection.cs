using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class InterfaceInjection : IDependencyNameServiceInjector
    {
        public IDependencyNameService NameService { get ; set; }

        public string SayHello()
        {
            return "Hello " + NameService.GetName();
        }
    }
}
