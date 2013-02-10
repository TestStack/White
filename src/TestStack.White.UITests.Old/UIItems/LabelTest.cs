using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture]
    public class LabelTest : ControlsActionTest
    {
        private Label label;

        [Test]
        public void Text()
        {
            label = Window.Get<Label>("result");
            Assert.AreNotEqual(null, label.Text);
        }
    }
}