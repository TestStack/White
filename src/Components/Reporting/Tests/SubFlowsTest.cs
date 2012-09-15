using NUnit.Framework;
using Reporting.Domain;

namespace White.Reporting.UnitTests
{
    [TestFixture]
    public class SubFlowsTest
    {
        private SubFlows flows;

        [SetUp]
        public void SetUp()
        {
            flows = new SubFlows("archiveLocation", "flowName");
        }

        [Test]
        public void Start()
        {
            flows.Begin("subflow1");
            flows.Next(typeof (One));
            flows.Act();
            flows.Next(typeof (Two));

            flows.Begin("subflow2");
            flows.Next(typeof (One));
            flows.Finish();
            Assert.AreEqual(2, flows.Count);
            Assert.AreEqual(2, flows[0].FlowSteps.Count);
            Assert.AreEqual(1, flows[1].FlowSteps.Count);
        }
    }
}