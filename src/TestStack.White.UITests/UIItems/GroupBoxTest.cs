using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory, WPFCategory]
    public class GroupBoxTest : ControlsActionTest
    {
        [Test]
        public void Find()
        {
            GroupBox groupBox = window.Get<GroupBox>("groupBox1");
            Assert.AreNotEqual(null, groupBox);
        }
    }

    [TestFixture, WinFormCategory]
    public class WinFormGroupBoxTest : ControlsActionTest
    {
        [Test]
        public void GetItem()
        {
            GroupBox groupBox = window.Get<GroupBox>("groupBox1");
            Button button = groupBox.Get<Button>("buttonInGroupBox");
            Assert.AreNotEqual(null, button);
        }
    }
}