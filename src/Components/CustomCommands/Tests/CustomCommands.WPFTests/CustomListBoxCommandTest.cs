using NUnit.Framework;
using White.Core.CustomCommands;
using White.Core.UIItems.ListBoxItems;

namespace White.CustomCommands.WPFTests
{
    [TestFixture]
    public class CustomListBoxCommandTest : WPFCustomCommandsTest
    {
        [Test]
        public void CustomCommandForListBox()
        {
            var listBox = window.Get<ListBox>("listBox");
            var listBoxCommands = new CustomCommandFactory().Create<IListBoxCommands>(listBox);
            Assert.AreEqual(2, listBoxCommands.ItemCount);
        }
    }
}