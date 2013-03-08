using NUnit.Framework;
using White.Core.Factory;
using White.Core.UIItems;
using White.Core.UIItems.WindowItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests
{
    [TestFixture]
    public class ApplicationTest : ControlsActionTest
    {
        [Test]
        public void GetWindows()
        {
            Assert.AreNotEqual(null, Window);
        }

        [Test]
        public void GetAllWindows()
        {
            Window.Get<Button>("launchModal").Click();
            int count = Application.GetWindows().Count;
            CloseModal(Window);
            Assert.AreEqual(2, count);
        }

        [Test]
        public void FindWindow()
        {
            Window.Get<Button>("launchModal").Click();
            Window foundWindow = Application.Find(obj => obj.Equals("ModalForm"), InitializeOption.NoCache);
            CloseModal(Window);
            Assert.AreNotEqual(null, foundWindow);
        }
    }
}