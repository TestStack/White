using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    public class LabelTest : ControlsActionTest
    {
        private Label label;

        [Fact]
        public void Text()
        {
            label = Window.Get<Label>("result");
            Assert.NotEqual(null, label.Text);
        }
    }
}