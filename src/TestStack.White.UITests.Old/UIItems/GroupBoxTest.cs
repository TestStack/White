using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory, WPFCategory]
    public class GroupBoxTest : ControlsActionTest
    {
        [Fact]
        public void Find()
        {
            GroupBox groupBox = Window.Get<GroupBox>("groupBox1");
            Assert.NotEqual(null, groupBox);
        }
    }

    [TestFixture, WinFormCategory]
    public class WinFormGroupBoxTest : ControlsActionTest
    {
        [Fact]
        public void GetItem()
        {
            GroupBox groupBox = Window.Get<GroupBox>("groupBox1");
            Button button = groupBox.Get<Button>("buttonInGroupBox");
            Assert.NotEqual(null, button);
        }
    }
}