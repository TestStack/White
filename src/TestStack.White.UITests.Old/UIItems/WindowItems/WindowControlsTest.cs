using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems.WindowItems
{
    public class WindowControlsTest : ControlsActionTest
    {
        [Fact]
        public void GetButton()
        {
            Assert.NotEqual(null, Window.Get<Button>("buton"));
        }

        [Fact]
        public void GetLabel()
        {
            Assert.NotEqual(null, Window.Get<Label>("result"));
        }
    }
}