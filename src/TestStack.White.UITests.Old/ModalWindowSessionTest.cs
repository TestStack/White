using NUnit.Framework;
using White.Core.Factory;
using White.Core.UIItems;
using White.Core.UIItems.WindowItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests
{
    [TestFixture, WinFormCategory]
    public class ModalWindowSessionTest : ControlsActionTest
    {
        [Test]
        public void GetControlFromModalWindow()
        {
            Window.Get<Button>("launchModal").Click();
            Window modalWindow = Window.ModalWindow("ModalForm", InitializeOption.NoCache.AndIdentifiedBy("ModalForm"));
            modalWindow.Get<Button>("ok").Click();
        }
    }
}