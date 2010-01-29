using NUnit.Framework;
using White.UnitTests.Core.Testing;

namespace White.Core.UIItems.WindowItems
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
            Assert.AreEqual(true, window.IsClosed);
        }
    }
}