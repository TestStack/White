using System;
using NUnit.Framework;
using Reporting.Domain;

namespace Reporting.Test
{
    [TestFixture]
    public class SubFlowTest
    {
        private SubFlow subFlow;

        [SetUp]
        public void SetUp()
        {
            subFlow = new SubFlow("subFlow", "flow", "archiveLocation");
        }

        [Test]
        public void NextOnSameNode()
        {
            subFlow.Next(One());
            subFlow.Act();
            subFlow.Act();
            Assert.AreEqual(1, subFlow.FlowSteps.Count);
            Assert.AreEqual(3, subFlow.FlowSteps[0].ScreenShots.Count);
        }

        [Test]
        public void Flow()
        {
            subFlow.Next(One());           
            subFlow.Act();           
            subFlow.Act();           
            subFlow.Next(Two());           
            subFlow.Act();
            Assert.AreEqual(2, subFlow.FlowSteps.Count);
            Assert.AreEqual(3, subFlow.FlowSteps[0].ScreenShots.Count);
            Assert.AreEqual(2, subFlow.FlowSteps[1].ScreenShots.Count);
        }

        private static Type One() {
            return typeof(One);
        }

        private static Type Two() {
            return typeof(Two);
        }

    }

    internal class One {}
    internal class Two {}
}