using Reporting.Domain;
using Xunit;

namespace White.Reporting.UITests
{
    public class SessionReportTest
    {
        readonly SessionReport report;

        public SessionReportTest()
        {
            report = new SessionReport("archiveLocation", "testName");
        }

        [Fact]
        public void ShouldBeEmptyWhenFirstCreated()
        {
            Assert.Equal(true, report.IsEmpty);
        }

        [Fact]
        public void Next()
        {
            report.Next(typeof(object));
            report.Next(typeof(object));
            Assert.Equal(1, report.SubFlows.Count);
            Assert.Equal(2, report.SubFlows[0].FlowSteps.Count);
        }

        [Fact]
        public void Start()
        {
            report.Begin("subFlow1");
            report.Next(typeof(object));
            report.Begin("subFlow2");
            report.Next(typeof(object));
            Assert.Equal(2, report.SubFlows.Count);

            report.Begin("subFlow3");
            report.Next(typeof(object));
            Assert.Equal(3, report.SubFlows.Count);
        }

        [Fact]
        public void ShouldAddANodeToTheCurrentSubFlow()
        {
            report.Begin("subFlow1");
            report.Next(typeof(object));
            report.Next(typeof(object));
            Assert.Equal(1, report.SubFlows.Count);
            Assert.Equal(2, report.SubFlows[0].FlowSteps.Count);

            report.Begin("subFlow2");
            report.Next(typeof(object));
            Assert.Equal(2, report.SubFlows.Count);
            Assert.Equal(2, report.SubFlows[0].FlowSteps.Count);
            Assert.Equal(1, report.SubFlows[1].FlowSteps.Count);
        }
    }
}