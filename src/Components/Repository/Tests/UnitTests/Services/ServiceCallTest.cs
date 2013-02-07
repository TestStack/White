using NUnit.Framework;
using Repository.Services;

namespace White.Repository.UnitTests.Services
{
    [TestFixture]
    public class ServiceCallTest
    {
        [Test]
        public void ShouldStoreParameterTypeOfMethod()
        {
            var type = typeof(TestServiceForServiceCallTest);
            var serviceCall = new ServiceCall(new TestServiceForServiceCallTest(), type.GetMethod("Method"));
            Assert.AreEqual("System.String", serviceCall.ParameterTypes[0]);
        }
    }

    public class TestServiceForServiceCallTest : Service
    {
        public virtual void Method(string s) {}
    }
}