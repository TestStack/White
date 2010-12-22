using NUnit.Framework;
using White.Core.CustomCommands;
using White.Core.UIItems.ListBoxItems;
using White.Core.UITests;
using White.Core.UITests.Testing;

namespace White.CustomCommands.WPFTests
{
    [TestFixture, WPFCategory]
    public class CustomListBoxCommandTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return "CustomWhiteControlsWindow"; }
        }

        [Test]
        public void CustomCommandForListBox()
        {
            var listBox = window.Get<ListBox>("listBox");
            var listBoxCommands = new CustomCommandFactory().Create<IListBoxCommands>(listBox);
            Assert.AreEqual(2, listBoxCommands.ItemCount);
        }
    }
}