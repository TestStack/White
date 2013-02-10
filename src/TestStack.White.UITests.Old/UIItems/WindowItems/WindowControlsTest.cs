using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.WindowItems
{
    [TestFixture]
    public class WindowControlsTest : ControlsActionTest
    {
        [Test]
        public void GetButton()
        {
            Assert.AreNotEqual(null, Window.Get<Button>("buton"));
        }

        [Test]
        public void GetLabel()
        {
            Assert.AreNotEqual(null, Window.Get<Label>("result"));
        }
    }
}