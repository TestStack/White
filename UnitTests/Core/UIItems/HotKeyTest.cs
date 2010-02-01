using NUnit.Framework;
using White.UnitTests.Core.Testing;

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