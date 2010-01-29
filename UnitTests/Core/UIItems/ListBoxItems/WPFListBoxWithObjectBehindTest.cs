using NUnit.Framework;
using White.Core;
using White.Core.UIItems.ListBoxItems;
using White.UnitTests.Core.Testing;

namespace White.UnitTests.Core.UIItems.ListBoxItems
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