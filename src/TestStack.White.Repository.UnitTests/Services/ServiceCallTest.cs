using White.Repository.Services;
using Xunit;

namespace White.Repository.UnitTests.Services
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