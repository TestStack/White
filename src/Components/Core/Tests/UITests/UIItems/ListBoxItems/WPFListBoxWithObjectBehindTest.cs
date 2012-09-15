using NUnit.Framework;
using White.Core.UIItems.ListBoxItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.ListBoxItems
{
    [TestFixture, WPFCategory]
    public class WPFListBoxWithObjectBehindTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return "ComboBoxWithObjectWindow"; }
        }

        [Test]
        public void SelectInvisible()
        {
            var listBox = window.Get<ListBox>("theListBox");
            listBox.Select("Tammy");
        }
    }
}