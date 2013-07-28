using TestStack.White.ScreenObjects.Services;
using Xunit;

namespace TestStack.White.UnitTests.Repository.Services
{
    public class ServiceCallTest
    {
        [Fact]
        public void ShouldStoreParameterTypeOfMethod()
        {
            var type = typeof(TestServiceForServiceCallTest);
            var serviceCall = new ServiceCall(new TestServiceForServiceCallTest(), type.GetMethod("Method"));
            Assert.Equal("System.String", serviceCall.ParameterTypes[0]);
        }
    }
}