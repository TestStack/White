using System;
using TestStack.White.ScreenObjects.Services;
using Xunit;

namespace TestStack.White.UnitTests.Repository.Services
{
    public class ServiceExecutionTest
    {
        private readonly ServiceExecution serviceExecution;
        private readonly ExecutionHistory executionHistory;
        private readonly Type type;

        public ServiceExecutionTest()
        {
            type = typeof(TestService);
            executionHistory = new ExecutionHistory();
            serviceExecution = new ServiceExecution(executionHistory, new NullWorkEnvironment());
        }

        [Fact]
        public void InvokingANewServiceShouldAddItToEventHistory()
        {
            LastServiceCallStatus callStatus = serviceExecution.Invoking(new TestService(), type.GetMethod("Method"));
            serviceExecution.Invoked(null);
            Assert.Equal(1, executionHistory.ServiceCalls.Count);
            Assert.Equal(false, callStatus.WasExecuted);
        }

        [Fact]
        public void InvokingAExistingServiceShouldReturnStatus()
        {
            var callInPreviousRun = new ServiceCall(new TestService(), type.GetMethod("Method"));
            executionHistory.Add(callInPreviousRun);
            callInPreviousRun.ReturnValue = string.Empty;

            LastServiceCallStatus callStatus = serviceExecution.Invoking(new TestService(), type.GetMethod("Method"));
            Assert.Equal(1, executionHistory.ServiceCalls.Count);
            Assert.NotEqual(null, callStatus);
            Assert.NotEqual(null, callStatus.ReturnValue);
        }
    }

    public class TestService : Service
    {
        public virtual string Method()
        {
            return string.Empty;
        }
    }
}