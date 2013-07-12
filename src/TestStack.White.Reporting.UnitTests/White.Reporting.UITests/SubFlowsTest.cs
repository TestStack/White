using Reporting.Domain;
using Xunit;

namespace White.Reporting.UITests
{
    public class SubFlowsTest
    {
        private readonly SubFlows flows;

        public SubFlowsTest()
        {
            flows = new SubFlows("archiveLocation", "flowName");
        }

        [Fact]
        public void Start()
        {
            flows.Begin("subflow1");
            flows.Next(typeof (One));
            flows.Act();
            flows.Next(typeof (Two));

            flows.Begin("subflow2");
            flows.Next(typeof (One));
            flows.Finish();
            Assert.Equal(2, flows.Count);
            Assert.Equal(2, flows[0].FlowSteps.Count);
            Assert.Equal(1, flows[1].FlowSteps.Count);
        }
    }
}