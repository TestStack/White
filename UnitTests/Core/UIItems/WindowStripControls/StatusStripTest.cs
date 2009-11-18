using NUnit.Framework;
using White.Core.Factory;
using White.Core.Testing;

namespace White.Core.UIItems.WindowStripControls
{
    [TestFixture, WinFormCategory]
    public class StatusStripTest : ControlsActionTest
    {
        private StatusStrip statusStrip;

        protected override void TestFixtureSetUp()
        {
            statusStrip = window.StatusBar(InitializeOption.NoCache);
        }

        [Test]
        public void Find()
        {
            Assert.AreEqual(null, window.Get<StatusStrip>("statusStrip1"));
            Assert.AreNotEqual(null, statusStrip);
        }

        [Test]
        public void FindLabelInsideStatusBar()
        {
            UIItem uiItem = statusStrip.GetLabel("Status Strip Label");
            Assert.AreNotEqual(null, uiItem);
        }

        [Test]
        public void ClickOnButtonAndFindPopupMenu()
        {
            StatusStripSplitButton statusStripSplitButton = statusStrip.GetSplitButton("toolStripSplitButtonText");
            Assert.AreNotEqual(null, statusStripSplitButton);
            statusStripSplitButton.Click();
        }

        [Test]
        public void FindDropDown()
        {
            StatusStripDropDownButton button = statusStrip.GetDropDownButton("toolStripDropDownButton");
            Assert.AreNotEqual(null, button);
            button.Click();
        }

        [Test]
        public void ProgressBar()
        {
            ProgressBar progressBar = statusStrip.GetProgressBar();
            Assert.AreEqual(0, progressBar.Minimum);
            Assert.AreEqual(33, progressBar.Value);
            Assert.AreEqual(100, progressBar.Maximum);
        }

        [Test]
        public void ProgressBar2()
        {
            ProgressBar progressBar = statusStrip.GetProgressBar(1);
            Assert.AreEqual(0, progressBar.Minimum);
            Assert.AreEqual(67, progressBar.Value);
            Assert.AreEqual(100, progressBar.Maximum);
        }
    }
}