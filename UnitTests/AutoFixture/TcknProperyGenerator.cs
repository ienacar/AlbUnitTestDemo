using AutoFixture.Kernel;
using System;
using System.Reflection;

namespace UnitTests.AutoFixture
{
    public class TcknProperyGenerator : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            var properyInfo = request as PropertyInfo;
            if(properyInfo is null)
            {
                return new NoSpecimen();
            }

            bool isTcknProperty = properyInfo.Name.Equals("TCKN");
            bool isStringType = properyInfo.PropertyType == typeof(string);

            if (isTcknProperty && isStringType)
            {
                return GenerateTckn();
            }

            return new NoSpecimen();
        }

        private object GenerateTckn()
        {
            return "11111111113";
        }
    }
}