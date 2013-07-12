using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests
{
    [TestFixture, WinFormCategory, WPFCategory]
    public class MessageBoxTest : ControlsActionTest
    {
        [Fact]
        public void CloseMessageBoxTest()
        {
            Window.Get<Button>("buttonLaunchesMessageBox").Click();
            Window messageBox = Window.MessageBox("Close Me");
            var label = Window.Get<Label>("65535");
            Assert.Equal("Close Me", label.Text);
            messageBox.Close();
        }

        [Fact]
        public void ClickButtonOnMessageBox()
        {
            Window.Get<Button>("buttonLaunchesMessageBox").Click();
            Window messageBox = Window.MessageBox("Close Me");
            messageBox.Get<Button>(SearchCriteria.ByText("OK")).Click();
        }
    }
}