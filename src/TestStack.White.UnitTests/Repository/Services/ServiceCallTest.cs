using NUnit.Framework;
using TestStack.White.ScreenObjects.Services;

namespace TestStack.White.UnitTests.Repository.Services
{
    [TestFixture]
    public class ServiceCallTest
    {
        [Test]
        public void ShouldStoreParameterTypeOfMethod()
        {
            var type = typeof(TestServiceForServiceCallTest);
            var serviceCall = new ServiceCall(new TestServiceForServiceCallTest(), type.GetMethod("Method"));
            Assert.That(serviceCall.ParameterTypes[0], Is.EqualTo("System.String"));
        }
    }
}