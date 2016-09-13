using NUnit.Framework;
using TestStack.White.Reporting.Domain;

namespace TestStack.White.UITests.Reporting
{
    [TestFixture]
    public class SubFlowsTests
    {
        private readonly SubFlows flows;

        public SubFlowsTests()
        {
            flows = new SubFlows("archiveLocation", "flowName");
        }

        [Test]
        public void Start()
        {
            flows.Begin("subflow1");
            flows.Next(typeof(One));
            flows.Act();
            flows.Next(typeof(Two));

            flows.Begin("subflow2");
            flows.Next(typeof(One));
            flows.Finish();
            Assert.That(flows, Has.Count.EqualTo(2));
            Assert.That(flows[0].FlowSteps, Has.Count.EqualTo(2));
            Assert.That(flows[1].FlowSteps, Has.Count.EqualTo(1));
        }
    }
}