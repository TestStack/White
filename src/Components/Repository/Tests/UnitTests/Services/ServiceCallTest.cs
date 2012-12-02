using Bricks.RuntimeFramework;
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
            var @class = new Class(typeof(TestServiceForServiceCallTest));
            var serviceCall = new ServiceCall(new TestServiceForServiceCallTest(), @class.GetMethod("Method").MethodInfo);
            Assert.AreEqual("System.String", serviceCall.ParameterTypes[0]);
        }
    }

    public class TestServiceForServiceCallTest : Service
    {
        public virtual void Method(string s) {}
    }
}