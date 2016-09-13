using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;
using TestStack.White.Configuration;
using TestStack.White.ScreenObjects.Services;

namespace TestStack.White.UnitTests.Repository.Services
{
    [TestFixture]
    public class ServiceExecutionTest
    {
        private ServiceExecution serviceExecution;
        private ExecutionHistory executionHistory;
        private Type type;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // Set the worksession path to the current assemblys directory
            var currentAssemblyDirectory = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            CoreAppXmlConfiguration.Instance.WorkSessionLocation = new DirectoryInfo(currentAssemblyDirectory);
        }

        [SetUp]
        public void Setup()
        {
            type = typeof(TestService);
            executionHistory = new ExecutionHistory();
            serviceExecution = new ServiceExecution(executionHistory, new NullWorkEnvironment());
        }

        [Test]
        public void InvokingANewServiceShouldAddItToEventHistory()
        {
            var callStatus = serviceExecution.Invoking(new TestService(), type.GetMethod("Method"));
            serviceExecution.Invoked(null);
            Assert.That(executionHistory.ServiceCalls, Has.Count.EqualTo(1));
            Assert.That(callStatus.WasExecuted, Is.False);
        }

        [Test]
        public void InvokingAExistingServiceShouldReturnStatus()
        {
            var callInPreviousRun = new ServiceCall(new TestService(), type.GetMethod("Method"));
            executionHistory.Add(callInPreviousRun);
            callInPreviousRun.ReturnValue = string.Empty;

            var callStatus = serviceExecution.Invoking(new TestService(), type.GetMethod("Method"));
            Assert.That(executionHistory.ServiceCalls, Has.Count.EqualTo(1));
            Assert.That(callStatus, Is.Not.Null);
            Assert.That(callStatus.ReturnValue, Is.Not.Null);
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