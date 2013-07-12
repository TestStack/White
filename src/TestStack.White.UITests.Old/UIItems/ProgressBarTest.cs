using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    public class ProgressBarTest : ControlsActionTest
    {
        private ProgressBar bar;

        protected override void TestFixtureSetUp()
        {
            bar = Window.Get<ProgressBar>("progressBar");
        }

        [Fact]
        public void MinimumValue()
        {
            Assert.Equal(0, bar.Minimum);
        }

        [Fact]
        public void MaximumValue()
        {
            Assert.Equal(100, bar.Maximum);
        }

        [Fact]
        public void Value()
        {
            Assert.Equal(50, bar.Value);
        }
    }
}