using System;
using NUnit.Framework;
using Repository.Services;

namespace White.Repository.UnitTests.Services
{
    [TestFixture]
    public class ServiceExecutionTest
    {
        private ServiceExecution serviceExecution;
        private ExecutionHistory executionHistory;
        private Type type;

        [SetUp]
        public void SetUp()
        {
            type = typeof(TestService);
            executionHistory = new ExecutionHistory();
            serviceExecution = new ServiceExecution(executionHistory, new NullWorkEnvironment());
        }

        [Test]
        public void InvokingANewServiceShouldAddItToEventHistory()
        {
            LastServiceCallStatus callStatus = serviceExecution.Invoking(new TestService(), type.GetMethod("Method"));
            serviceExecution.Invoked(null);
            Assert.AreEqual(1, executionHistory.ServiceCalls.Count);
            Assert.AreEqual(false, callStatus.WasExecuted);
        }

        [Test]
        public void InvokingAExistingServiceShouldReturnStatus()
        {
            var callInPreviousRun = new ServiceCall(new TestService(), type.GetMethod("Method"));
            executionHistory.Add(callInPreviousRun);
            callInPreviousRun.ReturnValue = string.Empty;

            LastServiceCallStatus callStatus = serviceExecution.Invoking(new TestService(), type.GetMethod("Method"));
            Assert.AreEqual(1, executionHistory.ServiceCalls.Count);
            Assert.AreNotEqual(null, callStatus);
            Assert.AreNotEqual(null, callStatus.ReturnValue);
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