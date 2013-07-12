using NUnit.Framework;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems.ListBoxItems
{
    [TestFixture, WPFCategory]
    public class WPFListBoxWithObjectBehindTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return "ComboBoxWithObjectWindow"; }
        }

        [Fact]
        public void SelectInvisible()
        {
            var listBox = Window.Get<ListBox>("theListBox");
            listBox.Select("Tammy");
        }
    }
}