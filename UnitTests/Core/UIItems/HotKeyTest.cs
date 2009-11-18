using NUnit.Framework;
using White.Core.Testing;

namespace White.Core.UIItems
{
    [TestFixture, WinFormCategory]
    public class HotKeyTest : ControlsActionTest
    {
        [Test]
        public void AccessKey()
        {
            Assert.AreEqual("Alt+B", window.Get<Button>("buton").AccessKey);
        }
    }
}