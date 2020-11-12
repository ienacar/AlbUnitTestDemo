using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class ConstructorInjection
    {
        private IDependencyNameService _nameService;

        public ConstructorInjection(IDependencyNameService nameService)
        {
            _nameService = nameService;
        }

        public string SayHello()
        {
            return "Hello " + _nameService.GetName();
        }
    }
}
