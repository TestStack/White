using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;
using TestStack.White.Reporting.Domain;

namespace TestStack.White.UITests.Reporting
{
    [TestFixture]
    public class SessionReportTests
    {
        [Test]
        public void ShouldBeEmptyWhenFirstCreated()
        {
            var report = CreateTestObject();
            Assert.That(report.IsEmpty, Is.True);
        }

        [Test]
        public void Next()
        {
            var report = CreateTestObject();
            report.Next(typeof(object));
            report.Next(typeof(object));
            Assert.That(report.SubFlows, Has.Count.EqualTo(1));
            Assert.That(report.SubFlows[0].FlowSteps, Has.Count.EqualTo(2));
        }

        [Test]
        public void Start()
        {
            var report = CreateTestObject();
            report.Begin("subFlow1");
            report.Next(typeof(object));
            report.Begin("subFlow2");
            report.Next(typeof(object));
            Assert.That(report.SubFlows, Has.Count.EqualTo(2));

            report.Begin("subFlow3");
            report.Next(typeof(object));
            Assert.That(report.SubFlows, Has.Count.EqualTo(3));
        }

        [Test]
        public void ShouldAddANodeToTheCurrentSubFlow()
        {
            var report = CreateTestObject();
            report.Begin("subFlow1");
            report.Next(typeof(object));
            report.Next(typeof(object));
            Assert.That(report.SubFlows, Has.Count.EqualTo(1));
            Assert.That(report.SubFlows[0].FlowSteps, Has.Count.EqualTo(2));

            report.Begin("subFlow2");
            report.Next(typeof(object));
            Assert.That(report.SubFlows, Has.Count.EqualTo(2));
            Assert.That(report.SubFlows[0].FlowSteps, Has.Count.EqualTo(2));
            Assert.That(report.SubFlows[1].FlowSteps, Has.Count.EqualTo(1));
        }

        private SessionReport CreateTestObject()
        {
            var currentAssemblyDirectory = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            return new SessionReport(Path.Combine(currentAssemblyDirectory, "archiveLocation"), "testName");
        }
    }
}