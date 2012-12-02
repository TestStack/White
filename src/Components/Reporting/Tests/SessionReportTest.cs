using NUnit.Framework;
using Reporting.Domain;

namespace White.Reporting.UnitTests
{
    [TestFixture]
    public class SessionReportTest
    {
        private SessionReport report;

        [SetUp]
        public void Setup()
        {
            report = new SessionReport("archiveLocation", "testName");
        }

        [Test]
        public void ShouldBeEmptyWhenFirstCreated()
        {
            Assert.AreEqual(true, report.IsEmpty);
        }

        [Test]
        public void Next()
        {
            report.Next(typeof(object));
            report.Next(typeof(object));
            Assert.AreEqual(1, report.SubFlows.Count);
            Assert.AreEqual(2, report.SubFlows[0].FlowSteps.Count);
        }

        [Test]
        public void Start()
        {
            report.Begin("subFlow1");
            report.Next(typeof(object));
            report.Begin("subFlow2");
            report.Next(typeof(object));
            Assert.AreEqual(2, report.SubFlows.Count);

            report.Begin("subFlow3");
            report.Next(typeof(object));
            Assert.AreEqual(3, report.SubFlows.Count);
        }

        [Test]
        public void ShouldAddANodeToTheCurrentSubFlow()
        {
            report.Begin("subFlow1");
            report.Next(typeof(object));
            report.Next(typeof(object));
            Assert.AreEqual(1, report.SubFlows.Count);
            Assert.AreEqual(2, report.SubFlows[0].FlowSteps.Count);

            report.Begin("subFlow2");
            report.Next(typeof(object));
            Assert.AreEqual(2, report.SubFlows.Count);
            Assert.AreEqual(2, report.SubFlows[0].FlowSteps.Count);
            Assert.AreEqual(1, report.SubFlows[1].FlowSteps.Count);
        }
    }
}