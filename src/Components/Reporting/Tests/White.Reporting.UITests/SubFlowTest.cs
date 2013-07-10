using System;
using Reporting.Domain;
using Xunit;

namespace White.Reporting.UITests
{
    public class SubFlowTest
    {
        readonly SubFlow subFlow;

        public SubFlowTest()
        {
            subFlow = new SubFlow("subFlow", "flow", "archiveLocation");
        }

        [Fact]
        public void NextOnSameNode()
        {
            subFlow.Next(One());
            subFlow.Act();
            subFlow.Act();
            Assert.Equal(1, subFlow.FlowSteps.Count);
            Assert.Equal(3, subFlow.FlowSteps[0].ScreenShots.Count);
        }

        [Fact]
        public void Flow()
        {
            subFlow.Next(One());           
            subFlow.Act();           
            subFlow.Act();           
            subFlow.Next(Two());           
            subFlow.Act();
            Assert.Equal(2, subFlow.FlowSteps.Count);
            Assert.Equal(3, subFlow.FlowSteps[0].ScreenShots.Count);
            Assert.Equal(2, subFlow.FlowSteps[1].ScreenShots.Count);
        }

        private static Type One() {
            return typeof(One);
        }

        private static Type Two() {
            return typeof(Two);
        }

    }
}