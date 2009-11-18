using NUnit.Framework;
using White.Core.Testing;

namespace White.Core.UIItems.ListBoxItems
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