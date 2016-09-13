using NUnit.Framework;
using System;
using System.Windows.Automation;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowStripControls;

namespace TestStack.White.UITests.ControlTests.WindowStripControls
{
    [TestFixture(WindowsFramework.WinForms)]
    public class StatusStripTests : WhiteUITestBase
    {
        private StatusStrip statusStrip;

        public StatusStripTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectOtherControls();
            statusStrip = MainWindow.StatusBar(InitializeOption.NoCache);
        }

        [Test]
        public void FindTest()
        {
            Assert.That(statusStrip, Is.Not.Null);
        }

        [Test]
        public void ThrowsWhenDoesNotExistsTest()
        {
            using (CoreAppXmlConfiguration.Instance.ApplyTemporarySetting(c => c.BusyTimeout = 100))
            {
                Assert.That(() => { MainWindow.Get<StatusStrip>("foo"); },
                    Throws.TypeOf<AutomationException>().With.
                    Message.EqualTo(String.Format("Failed to get ControlType={0},AutomationId=foo",
                        ControlType.StatusBar.LocalizedControlType)));
            }
        }

        [Test]
        [Category("NeedsFix")]
        [Ignore("NeedsFix")]
        public void FindLabelInsideStatusBarTest()
        {
            var uiItem = statusStrip.GetLabel("Status Strip Label");
            Assert.That(uiItem, Is.Not.Null);
        }

        [Test]
        [Category("NeedsFix")]
        [Ignore("NeedsFix")]
        public void ClickOnButtonAndFindPopupMenuTest()
        {
            var statusStripSplitButton = statusStrip.GetSplitButton("toolStripSplitButtonText");
            Assert.That(statusStripSplitButton, Is.Not.Null);
            statusStripSplitButton.Click();
        }

        [Test]
        [Category("NeedsFix")]
        [Ignore("NeedsFix")]
        public void FindDropDownTest()
        {
            var button = statusStrip.GetDropDownButton("toolStripDropDownButton");
            Assert.That(button, Is.Not.Null);
            button.Click();
        }

        [Test]
        public void ProgressBarTest()
        {
            var progressBar = statusStrip.GetProgressBar();
            Assert.That(progressBar.Minimum, Is.EqualTo(0));
            Assert.That(progressBar.Value, Is.EqualTo(33));
            Assert.That(progressBar.Maximum, Is.EqualTo(100));
        }

        [Test]
        [Ignore("For some reason, UIA returns each element twice so the index 1 is the same item as with index 0")]
        public void ProgressBar2Test()
        {
            var progressBar = statusStrip.GetProgressBar(1);
            Assert.That(progressBar.Minimum, Is.EqualTo(0));
            Assert.That(progressBar.Value, Is.EqualTo(67));
            Assert.That(progressBar.Maximum, Is.EqualTo(100));
        }
    }
}