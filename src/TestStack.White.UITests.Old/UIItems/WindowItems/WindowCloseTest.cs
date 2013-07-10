using NUnit.Framework;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.WindowItems
{
    public class WindowCloseTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return "ModalAtClose"; }
        }

        [Fact]
        public void CloseWhenModalWindowIsLaunchedAtClose()
        {
            Window.Close();
            CloseModal(Window);
        }

        protected override void BaseTestFixtureTearDown() {}
    }

    public class WindowIsClosedTest : ControlsActionTest
    {
        [Fact]
        public void IsClosed()
        {
            Assert.Equal(false, Window.IsClosed);
            Window.Close();
            Window.WaitTill(() => Window.IsClosed);
            Assert.Equal(true, Window.IsClosed);
        }
    }
}