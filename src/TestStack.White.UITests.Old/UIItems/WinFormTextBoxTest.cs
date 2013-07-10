using System.Threading;
using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.ListViewItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory]
    public class WinFormTextBoxTest : ControlsActionTest
    {
        private WinFormTextBox textBox;

        protected override void TestFixtureSetUp()
        {
            textBox = (WinFormTextBox) Window.Get<TextBox>("textBox");
        }

        [Fact]
        public void SuggestionList()
        {
            textBox.Text = "h";
            SuggestionList suggestionList = textBox.SuggestionList;
            Assert.Equal(2, suggestionList.Items.Count);
            Assert.Equal("hello", suggestionList.Items[0]);
            Assert.Equal("hi", suggestionList.Items[1]);
        }

        [Fact]
        public void SelectFromSuggestionList()
        {
            textBox.Enter("h");
            SuggestionList suggestionList = textBox.SuggestionList;
            suggestionList.Select("hello");
            Assert.Equal("hello", textBox.Text);
        }
    }
}