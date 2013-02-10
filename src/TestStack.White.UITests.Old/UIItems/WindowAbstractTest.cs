using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    public abstract class WindowAbstractTest : ControlsActionTest
    {
        [Test]
        public void IsCurrentlyActive()
        {
            Window.Focus();
            Assert.AreEqual(true, Window.IsCurrentlyActive);
            Window.Get<Button>("buton").Click();
            Assert.AreEqual(true, Window.IsCurrentlyActive);
        }

        [Test]
        public void IsCurrentlyNotActive()
        {
            Application otherApplication = OtherConfiguration().Launch();
            using (otherApplication)
            {
                otherApplication.GetWindow("Form1").Focus();
                Assert.AreEqual(false, Window.IsCurrentlyActive);
            }
        }

        protected abstract TestConfiguration OtherConfiguration();
    }
}