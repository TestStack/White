using NUnit.Framework;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems.WindowStripControls
{
    [TestFixture, WinFormCategory]
    public class StatusStripTest : ControlsActionTest
    {
        private StatusStrip statusStrip;

        protected override void TestFixtureSetUp()
        {
            statusStrip = Window.StatusBar(InitializeOption.NoCache);
        }

        [Fact]
        public void Find()
        {
            Assert.NotEqual(null, statusStrip);
        }

        [Fact]
        public void ThrowsWhenDoesNotExists()
        {
            var exception = Assert.Throws<AutomationException>(()=> Window.Get<StatusStrip>("statusStrip1"));

            Assert.Equal("Failed to get ControlType=status bar,AutomationId=statusStrip1", exception.Message);
        }

        [Fact]
        public void FindLabelInsideStatusBar()
        {
            UIItem uiItem = statusStrip.GetLabel("Status Strip Label");
            Assert.NotEqual(null, uiItem);
        }

        [Fact]
        public void ClickOnButtonAndFindPopupMenu()
        {
            StatusStripSplitButton statusStripSplitButton = statusStrip.GetSplitButton("toolStripSplitButtonText");
            Assert.NotEqual(null, statusStripSplitButton);
            statusStripSplitButton.Click();
        }

        [Fact]
        public void FindDropDown()
        {
            StatusStripDropDownButton button = statusStrip.GetDropDownButton("toolStripDropDownButton");
            Assert.NotEqual(null, button);
            button.Click();
        }

        [Fact]
        public void ProgressBar()
        {
            ProgressBar progressBar = statusStrip.GetProgressBar();
            Assert.Equal(0, progressBar.Minimum);
            Assert.Equal(33, progressBar.Value);
            Assert.Equal(100, progressBar.Maximum);
        }

        [Fact(Skip = "Doesnt work on build server")]
        public void ProgressBar2()
        {
            ProgressBar progressBar = statusStrip.GetProgressBar(1);
            Assert.Equal(0, progressBar.Minimum);
            Assert.Equal(67, progressBar.Value);
            Assert.Equal(100, progressBar.Maximum);
        }
    }
}