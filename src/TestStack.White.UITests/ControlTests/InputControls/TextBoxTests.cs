using NUnit.Framework;
using System;
using System.Threading;
using System.Windows;
using TestStack.White.UIItems;
using TestStack.White.Utility;
using TestStack.White.WindowsAPI;

namespace TestStack.White.UITests.ControlTests.InputControls
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class TextBoxTests : WhiteUITestBase
    {
        public TextBoxTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectInputControls();
        }

        [Test]
        public void EnterTextTest()
        {
            var textBox = MainWindow.Get<TextBox>("TextBox");
            textBox.Text = "somethingElse";
            Assert.That(textBox.Text, Is.EqualTo("somethingElse"));
            Assert.That(textBox.HelpText, Is.EqualTo("Text Changed"));
            textBox.Text = "";
            Assert.That(textBox.Text, Is.EqualTo(""));
            textBox.Text = "againSomethingElse";
            Assert.That(textBox.Text, Is.EqualTo("againSomethingElse"));
        }

        [Test]
        public void EnterBulkTextTest()
        {
            var textBox = MainWindow.Get<TextBox>("TextBox");
            textBox.BulkText = "somethingElse";
            Assert.That(textBox.Text, Is.EqualTo("somethingElse"));
        }

        [Test, Apartment(ApartmentState.STA)]
        public void CopyTest()
        {
            var textBox = MainWindow.Get<TextBox>("TextBox");
            var attachedKeyboard = MainWindow.Keyboard;
            textBox.Text = "userText";
            attachedKeyboard.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            attachedKeyboard.Enter("ac");
            attachedKeyboard.LeaveKey(KeyboardInput.SpecialKeys.CONTROL);

            //check the text is the same as that on the clipboard
            Retry.For(() =>
            {
                var clipbrdText = Clipboard.GetText();
                Assert.That(clipbrdText, Is.EqualTo(textBox.Text));
            }, TimeSpan.FromSeconds(5));
        }

        [Test]
        public void SuggestionListTest()
        {
            if (Framework != WindowsFramework.WinForms)
            {
                Assert.Ignore();
            }
            var textBox = MainWindow.Get<WinFormTextBox>("TextBox");
            textBox.Text = "h";
            var suggestionList = textBox.SuggestionList;
            Assert.That(suggestionList.Items, Has.Count.EqualTo(2));
            Assert.That(suggestionList.Items[0], Is.EqualTo("hello"));
            Assert.That(suggestionList.Items[1], Is.EqualTo("hi"));
        }

        [Test]
        public void SelectFromSuggestionListTest()
        {
            if (Framework != WindowsFramework.WinForms)
            {
                Assert.Ignore();
            }
            var textBox = MainWindow.Get<WinFormTextBox>("TextBox");
            textBox.Enter("h");
            var suggestionList = textBox.SuggestionList;
            suggestionList.Select("hello");
            Assert.That(textBox.Text, Is.EqualTo("hello"));
        }

        [Test]
        public void IsReadOnlyTest()
        {
            var textBox = MainWindow.Get<TextBox>("TextBox");
            Assert.That(textBox.IsReadOnly, Is.False);
        }
    }
}