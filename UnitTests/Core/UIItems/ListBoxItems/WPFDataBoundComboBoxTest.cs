using NUnit.Framework;
using White.Core.Testing;

namespace White.Core.UIItems.ListBoxItems
{
    [TestFixture, WPFCategory]
    public class WPFDataBoundComboBoxTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return WPFScenarioSet1; }
        }

        [Test]
        public void Select()
        {
            ListItems items = window.Get<ComboBox>("dataBoundComboBox").Items;
            Assert.AreEqual(1, items.Count);
            Assert.AreEqual("S P Kumar", items[0].Text);
        }
    }
}