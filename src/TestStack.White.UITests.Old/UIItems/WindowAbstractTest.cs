using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    public abstract class WindowAbstractTest : ControlsActionTest
    {
        [Fact]
        public void IsCurrentlyActive()
        {
            Window.Focus();
            Assert.Equal(true, Window.IsCurrentlyActive);
            Window.Get<Button>("buton").Click();
            Assert.Equal(true, Window.IsCurrentlyActive);
        }

        [Fact]
        public void IsCurrentlyNotActive()
        {
            Application otherApplication = OtherConfiguration().Launch();
            using (otherApplication)
            {
                otherApplication.GetWindow("Form1").Focus();
                Assert.Equal(false, Window.IsCurrentlyActive);
            }
        }

        protected abstract TestConfiguration OtherConfiguration();
    }
}