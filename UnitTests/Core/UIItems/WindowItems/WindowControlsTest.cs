using NUnit.Framework;
using White.Core.Testing;

namespace White.Core.UIItems.WindowItems
{
    [TestFixture]
    public class WindowControlsTest : ControlsActionTest
    {
        [Test]
        public void GetButton()
        {
            Assert.AreNotEqual(null, window.Get<Button>("buton"));
        }

        [Test]
        public void GetLabel()
        {
            Assert.AreNotEqual(null, window.Get<Label>("result"));
        }
    }
}