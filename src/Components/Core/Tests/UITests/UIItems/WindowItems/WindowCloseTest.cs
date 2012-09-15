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
            window.Close();
            CloseModal(window);
        }

        protected override void BaseTestFixtureTearDown() {}
    }

    [TestFixture]
    public class WindowIsClosedTest : ControlsActionTest
    {
        [Test]
        public void IsClosed()
        {
            Assert.AreEqual(false, window.IsClosed);
            window.Close();
            window.WaitTill(() => window.IsClosed);
            Assert.AreEqual(true, window.IsClosed);
        }
    }
}