using NUnit.Framework;
using White.Core.Testing;

namespace White.Core.UIItems
{
    [TestFixture]
    public class ProgressBarTest : ControlsActionTest
    {
        private ProgressBar bar;

        protected override void TestFixtureSetUp()
        {
            bar = window.Get<ProgressBar>("progressBar");
        }

        [Test]
        public void MinimumValue()
        {
            Assert.AreEqual(0, bar.Minimum);
        }

        [Test]
        public void MaximumValue()
        {
            Assert.AreEqual(100, bar.Maximum);
        }

        [Test]
        public void Value()
        {
            Assert.AreEqual(50, bar.Value);
        }
    }
}