using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory]
    public class HotKeyTest : ControlsActionTest
    {
        [Test]
        public void AccessKey()
        {
            Assert.AreEqual("Alt+B", Window.Get<Button>("buton").AccessKey);
        }
    }
}