using System;
using System.Collections.Generic;
using System.Windows;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListViewItems;
using TestStack.White.Utility;
using TestStack.White.WindowsAPI;
using Xunit;

namespace TestStack.White.UITests.ControlTests.InputControls
{
    public class TextBoxTest : WhiteTestBase
    {
        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            SelectInputControls();
            RunTest(IsReadOnly);
            RunTest(CopyTest);
            RunTest(EnterText);
            RunTest(EnterBulkText);
            RunTest(SuggestionList, WindowsFramework.WinForms);
            RunTest(SelectFromSuggestionList, WindowsFramework.WinForms);
        }

        void EnterText()
        {
            var textBox = MainWindow.Get<TextBox>("TextBox");
            textBox.Text = "somethingElse";
            Assert.Equal("somethingElse", textBox.Text);
            Assert.Equal("Text Changed", textBox.HelpText);
            textBox.Text = "";
            Assert.Equal("", textBox.Text);
            textBox.Text = "againSomethingElse";
            Assert.Equal("againSomethingElse", textBox.Text);
        }

        void EnterBulkText()
        {
            var textBox = MainWindow.Get<TextBox>("TextBox");
            textBox.BulkText = "somethingElse";
            Assert.Equal("somethingElse", textBox.Text);
        }

        void CopyTest()
        {
            var textBox = MainWindow.Get<TextBox>("TextBox");
            AttachedKeyboard attachedKeyboard = MainWindow.Keyboard;
            textBox.Text = "userText";
            attachedKeyboard.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            attachedKeyboard.Enter("ac");
            attachedKeyboard.LeaveKey(KeyboardInput.SpecialKeys.CONTROL);


            //check the text is the same as that on the clipboard
            Retry.For(() =>
            {
                string clipbrdText = Clipboard.GetText();
                Assert.Equal(textBox.Text, clipbrdText);
            }, TimeSpan.FromSeconds(5));
        }

        void SuggestionList()
        {
            var textBox = MainWindow.Get<WinFormTextBox>("TextBox");
            textBox.Text = "h";
            SuggestionList suggestionList = textBox.SuggestionList;
            Assert.Equal(2, suggestionList.Items.Count);
            Assert.Equal("hello", suggestionList.Items[0]);
            Assert.Equal("hi", suggestionList.Items[1]);
        }

        void SelectFromSuggestionList()
        {
            var textBox = MainWindow.Get<WinFormTextBox>("TextBox");
            textBox.Enter("h");
            SuggestionList suggestionList = textBox.SuggestionList;
            suggestionList.Select("hello");
            Assert.Equal("hello", textBox.Text);
        }

        void IsReadOnly()
        {
            var textBox = MainWindow.Get<TextBox>("TextBox");
            Assert.Equal(false, textBox.IsReadOnly);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
            yield return WindowsFramework.Wpf;
        }
    }
}