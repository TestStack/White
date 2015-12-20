using NUnit.Framework;
using TestStack.White.Reporting.Domain;

namespace TestStack.White.UITests.Reporting
{
    [TestFixture]
    public class SessionReportTests
    {
        readonly SessionReport report;

        public SessionReportTests()
        {
            report = new SessionReport("archiveLocation", "testName");
        }

        [Test]
        public void ShouldBeEmptyWhenFirstCreated()
        {
            Assert.That(report.IsEmpty, Is.True);
        }

        [Test]
        public void Next()
        {
            report.Next(typeof(object));
            report.Next(typeof(object));
            Assert.That(report.SubFlows, Has.Count.EqualTo(1));
            Assert.That(report.SubFlows[0].FlowSteps, Has.Count.EqualTo(2));
        }

        [Test]
        public void Start()
        {
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
    }
}