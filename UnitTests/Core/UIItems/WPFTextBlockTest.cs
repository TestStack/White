using NUnit.Framework;
using White.UnitTests.Core.Testing;

namespace White.Core.UIItems
{
    [TestFixture, WPFCategory]
    public class WPFTextBlockTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return WPFScenarioSet1; }
        }

        [Test]
        public void Find()
        {
            Label label = window.Get<Label>("textBlock1");
            Assert.AreNotEqual(null, label);
        }
    }
}