using NUnit.Framework;
using White.Core.UIItems.ListBoxItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.ListBoxItems
{
    [TestFixture, WinFormCategory, WPFCategory]
    public class CheckedListBoxTest : ControlsActionTest
    {
        private ListBox listBox;

        protected override void TestFixtureSetUp()
        {
            listBox = window.Get<ListBox>("chequedListBox");
        }

        [SetUp]
        public void SetUp()
        {
            listBox.Select("Bill Gates");
            listBox.Check("Bill Gates");
            listBox.UnCheck("Bill Gates");
            listBox.Select("Narayan Murthy");
            listBox.Check("Narayan Murthy");
            listBox.UnCheck("Narayan Murthy");
        }

        [Test]
        public void IsChecked()
        {
            Assert.AreEqual(false, listBox.IsChecked("Bill Gates"));
        }

        [Test]
        public void Check()
        {
            Assert.AreEqual(false, listBox.IsChecked("Bill Gates"));
            listBox.Check("Bill Gates");
            Assert.AreEqual(true, listBox.IsChecked("Bill Gates"));
        }

        [Test]
        public void UnCheck()
        {
            Assert.AreEqual(false, listBox.IsChecked("Bill Gates"));
            listBox.Check("Bill Gates");
            Assert.AreEqual(true, listBox.IsChecked("Bill Gates"));
            listBox.UnCheck("Bill Gates");
            Assert.AreEqual(false, listBox.IsChecked("Bill Gates"));
        }
    }
}