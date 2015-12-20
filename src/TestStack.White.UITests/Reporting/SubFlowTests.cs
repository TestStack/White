using System;
using NUnit.Framework;
using TestStack.White.Reporting.Domain;

namespace TestStack.White.UITests.Reporting
{
    [TestFixture]
    public class SubFlowTests
    {
        readonly SubFlow subFlow;

        public SubFlowTests()
        {
            subFlow = new SubFlow("subFlow", "flow", "archiveLocation");
        }

        [Test]
        public void NextOnSameNode()
        {
            subFlow.Next(One());
            subFlow.Act();
            subFlow.Act();
            Assert.That(subFlow.FlowSteps, Has.Count.EqualTo(1));
            Assert.That(subFlow.FlowSteps[0].ScreenShots, Has.Count.EqualTo(3));
        }

        [Test]
        public void Flow()
        {
            subFlow.Next(One());           
            subFlow.Act();           
            subFlow.Act();           
            subFlow.Next(Two());           
            subFlow.Act();
            Assert.That(subFlow.FlowSteps, Has.Count.EqualTo(2));
            Assert.That(subFlow.FlowSteps[0].ScreenShots, Has.Count.EqualTo(3));
            Assert.That(subFlow.FlowSteps[1].ScreenShots, Has.Count.EqualTo(2));
        }

        private static Type One() {
            return typeof(One);
        }

        private static Type Two() {
            return typeof(Two);
        }
    }
}