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
            Window.Get<Button>("buttonLaunchesMessageBox").Click();
            Window messageBox = Window.MessageBox("Close Me");
            var label = Window.Get<Label>("65535");
            Assert.AreEqual("Close Me", label.Text);
            messageBox.Close();
        }

        [Test]
        public void ClickButtonOnMessageBox()
        {
            Window.Get<Button>("buttonLaunchesMessageBox").Click();
            Window messageBox = Window.MessageBox("Close Me");
            // the same problem with default text localization, so in regular message box
            // we have Close (x) button with "Close" id and OK button with "2" id
            messageBox.Get<Button>(SearchCriteria.ByAutomationId("2")).Click();
        }
    }
}