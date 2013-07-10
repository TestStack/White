using NUnit.Framework;
using White.Core.Factory;
using White.Core.UIItems;
using White.Core.UIItems.WindowItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests
{
    public class ApplicationTest : ControlsActionTest
    {
        [Fact]
        public void GetWindows()
        {
            Assert.NotEqual(null, Window);
        }

        [Fact]
        public void GetAllWindows()
        {
            Window.Get<Button>("launchModal").Click();
            int count = Application.GetWindows().Count;
            CloseModal(Window);
            Assert.Equal(2, count);
        }

        [Fact]
        public void FindWindow()
        {
            Window.Get<Button>("launchModal").Click();
            Window foundWindow = Application.Find(obj => obj.Equals("ModalForm"), InitializeOption.NoCache);
            CloseModal(Window);
            Assert.NotEqual(null, foundWindow);
        }
    }
}