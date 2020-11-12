using DependencyInjection;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.DependencyInjection
{
    public class DependencyInjectionShould
    {
        [Test]
        public void ConstructorTest()
        {
            //arrange
            var nameService = new DependencyNameServiceImpl("constructor");
            var constructorInjector = new ConstructorInjection(nameService);
            string expectedString = "Hello constructor";
            //act
            string sayHello = constructorInjector.SayHello();

            //assert
            Assert.That(sayHello,Is.EqualTo(expectedString));
        }

        [Test]
        public void PropertyTest()
        {
            //arrange
            var nameService = new DependencyNameServiceImpl("property");
            var propertyInjector = new PropertyInjection();
            string expectedString = "Hello property";
            //act
            propertyInjector.NameService = nameService;
            string sayHello = propertyInjector.SayHello();

            //assert
            Assert.That(sayHello, Is.EqualTo(expectedString));
        }

        [Test]
        public void InterfaceTest()
        {
            //arrange
            var nameService = new DependencyNameServiceImpl("interface");
            var interfaceInjector = new InterfaceInjection();
            string expectedString = "Hello interface";
            //act
            interfaceInjector.NameService = nameService;
            string sayHello = interfaceInjector.SayHello();

            //assert
            Assert.That(sayHello, Is.EqualTo(expectedString));
        }

        [Test]
        public void MoqConstructorTest()
        {
            //arrange
            var nameService = new Mock<IDependencyNameService>();
            nameService.Setup(x => x.GetName()).Returns("constructor");

            var constructorInjector = new ConstructorInjection(nameService.Object);
            string expectedString = "Hello constructor";
            //act
            string sayHello = constructorInjector.SayHello();

            //assert
            Assert.That(sayHello, Is.EqualTo(expectedString));
        }

        [Test]
        public void MoqPropertyTest()
        {
            //arrange
            var nameService = new Mock<IDependencyNameService>();
            nameService.Setup(x => x.GetName()).Returns("property");

            var propertyInjector = new PropertyInjection();
            string expectedString = "Hello property";
            //act
            propertyInjector.NameService = nameService.Object;
            string sayHello = propertyInjector.SayHello();

            //assert
            Assert.That(sayHello, Is.EqualTo(expectedString));
        }

        [Test]
        public void MoqInterfaceTest()
        {
            //arrange
            var nameService = new Mock<IDependencyNameService>();
            nameService.Setup(x => x.GetName()).Returns("interface");

            var interfaceInjector = new InterfaceInjection();
            string expectedString = "Hello interface";
            //act
            interfaceInjector.NameService = nameService.Object;
            string sayHello = interfaceInjector.SayHello();

            //assert
            Assert.That(sayHello, Is.EqualTo(expectedString));
        }

    }
}
