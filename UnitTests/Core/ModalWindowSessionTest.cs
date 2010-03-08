using NUnit.Framework;
using White.Core;
using White.Core.Factory;
using White.Core.UIItems;
using White.Core.UIItems.WindowItems;
using White.UnitTests.Core.Testing;

namespace White.UnitTests.Core
{
    [TestFixture, WinFormCategory]
    public class ModalWindowSessionTest : ControlsActionTest
    {
        [Test]
        public void GetControlFromModalWindow()
        {
            window.Get<Button>("launchModal").Click();
            Window modalWindow = window.ModalWindow("ModalForm", InitializeOption.NoCache.AndIdentifiedBy("ModalForm"));
            modalWindow.Get<Button>("ok").Click();
        }
    }
}