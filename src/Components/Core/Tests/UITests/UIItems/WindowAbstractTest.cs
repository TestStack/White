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
            window.Focus();
            Assert.AreEqual(true, window.IsCurrentlyActive);
            window.Get<Button>("buton").Click();
            Assert.AreEqual(true, window.IsCurrentlyActive);
        }

        [Test]
        public void IsCurrentlyNotActive()
        {
            Application otherApplication = OtherConfiguration().Launch();
            using (otherApplication)
            {
                otherApplication.GetWindow("Form1").Focus();
                Assert.AreEqual(false, window.IsCurrentlyActive);
            }
        }

        protected abstract TestConfiguration OtherConfiguration();
    }
}