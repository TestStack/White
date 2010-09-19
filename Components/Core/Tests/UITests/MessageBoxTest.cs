using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests
{
    [TestFixture, WinFormCategory, WPFCategory]
    public class MessageBoxTest : ControlsActionTest
    {
        [Test]
        public void CloseMessageBoxTest()
        {
            window.Get<Button>("buttonLaunchesMessageBox").Click();
            Window messageBox = window.MessageBox("Close Me");
            var label = window.Get<Label>("65535");
            Assert.AreEqual("Close Me", label.Text);
            messageBox.Close();
        }

        [Test]
        public void ClickButtonOnMessageBox()
        {
            window.Get<Button>("buttonLaunchesMessageBox").Click();
            Window messageBox = window.MessageBox("Close Me");
            messageBox.Get<Button>(SearchCriteria.ByText("OK")).Click();
        }
    }
}