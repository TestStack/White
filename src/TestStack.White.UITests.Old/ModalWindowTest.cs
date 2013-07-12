using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UITests.Testing;
using Xunit;

namespace White.Core.UITests
{
    [TestFixture, WinFormCategory/*, SWTCategory*/] //TODO Get SWT working
    public class ModalWindowTest : ControlsActionTest, IDisposable
    {
        [Fact]
        public void NoModalWindowExists()
        {
            Window modalWindow = Window.ModalWindow("foo");
            Assert.Equal(null, modalWindow);
        }

        [Fact]
        public void GetModalWindow()
        {
            LaunchModalWindow();
            Window modalWindow = Window.ModalWindow("ModalForm");
            Assert.NotEqual(null, modalWindow);
        }

        private void LaunchModalWindow()
        {
            Window.Get<Button>("launchModal").Click();
        }

        [Fact]
        public void GetModalWindowBasedOnSearchCriteria()
        {
            LaunchModalWindow();
            Window modalWindow = Window.ModalWindow(SearchCriteria.ByText("ModalForm"));
            Assert.NotEqual(null, modalWindow);
        }

        public void Dispose()
        {
            CloseModal(Window);
        }
    }
}