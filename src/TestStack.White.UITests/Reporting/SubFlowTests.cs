using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;
using TestStack.White.Reporting.Domain;

namespace TestStack.White.UITests.Reporting
{
    [TestFixture]
    public class SubFlowTests
    {
        [Test]
        public void NextOnSameNode()
        {
            var subFlow = CreateTestObject();
            subFlow.Next(One());
            subFlow.Act();
            subFlow.Act();
            Assert.That(subFlow.FlowSteps, Has.Count.EqualTo(1));
            Assert.That(subFlow.FlowSteps[0].ScreenShots, Has.Count.EqualTo(3));
        }

        [Test]
        public void Flow()
        {
            var subFlow = CreateTestObject();
            subFlow.Next(One());
            subFlow.Act();
            subFlow.Act();
            subFlow.Next(Two());
            subFlow.Act();
            Assert.That(subFlow.FlowSteps, Has.Count.EqualTo(2));
            Assert.That(subFlow.FlowSteps[0].ScreenShots, Has.Count.EqualTo(3));
            Assert.That(subFlow.FlowSteps[1].ScreenShots, Has.Count.EqualTo(2));
        }

        private SubFlow CreateTestObject()
        {
            var currentAssemblyDirectory = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            return new SubFlow("subFlow", "flow", Path.Combine(currentAssemblyDirectory, "archiveLocation"));
        }

        private static Type One()
        {
            return typeof(One);
        }

        private static Type Two()
        {
            return typeof(Two);
        }
    }
}