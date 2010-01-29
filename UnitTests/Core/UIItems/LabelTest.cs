using NUnit.Framework;
using White.UnitTests.Core.Testing;

namespace White.Core.UIItems
{
    [TestFixture]
    public class LabelTest : ControlsActionTest
    {
        private Label label;

        [Test]
        public void Text()
        {
            label = window.Get<Label>("result");
            Assert.AreNotEqual(null, label.Text);
        }
    }
}