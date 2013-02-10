using NUnit.Framework;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.WindowItems
{
    [TestFixture]
    public class WindowCloseTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return "ModalAtClose"; }
        }

        [Test]
        public void CloseWhenModalWindowIsLaunchedAtClose()
        {
            Window.Close();
            CloseModal(Window);
        }

        protected override void BaseTestFixtureTearDown() {}
    }

    [TestFixture]
    public class WindowIsClosedTest : ControlsActionTest
    {
        [Test]
        public void IsClosed()
        {
            Assert.AreEqual(false, Window.IsClosed);
            Window.Close();
            Window.WaitTill(() => Window.IsClosed);
            Assert.AreEqual(true, Window.IsClosed);
        }
    }
}