using NUnit.Framework;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests
{
    [TestFixture, WinFormCategory]
    public class ModalWindowSessionTest : ControlsActionTest
    {
        [Fact]
        public void GetControlFromModalWindow()
        {
            Window.Get<Button>("launchModal").Click();
            Window modalWindow = Window.ModalWindow("ModalForm", InitializeOption.NoCache.AndIdentifiedBy("ModalForm"));
            modalWindow.Get<Button>("ok").Click();
        }
    }
}