using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
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
            Label label = Window.Get<Label>("textBlock1");
            Assert.AreNotEqual(null, label);
        }
    }
}