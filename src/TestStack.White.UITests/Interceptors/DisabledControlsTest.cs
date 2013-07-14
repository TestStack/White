using System;
using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.Utility;
using Xunit;

namespace TestStack.White.UITests.Interceptors
{
    //TODO: Check all operations and write tests possible on all disabled uiitem
    public class DisabledControlsTest : WhiteTestBase
    {
        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(DoNotAllowActionOnDisabledControls);
            RunTest(AllowActionsPossibleOnDisabledInputControls);
            RunTest(AllowActionsPossibleOnDisabledListControls);
        }

        void DoNotAllowActionOnDisabledControls()
        {
            SelectInputControls();
            var textBox = MainWindow.Get<TextBox>("TextBox");
            MainWindow.Get<Button>("DisableControls").Click();
            Retry.For(() => !textBox.Enabled, TimeSpan.FromSeconds(2));
            Assert.Throws<ElementNotEnabledException>(() => { textBox.Text = "blah"; });
            MainWindow.Get<Button>("DisableControls").Click();
        }

        void AllowActionsPossibleOnDisabledInputControls()
        {
            SelectInputControls();
            var textBox = MainWindow.Get<TextBox>("TextBox");

            // Set Values
            textBox.Text = "blah";

            MainWindow.Get<Button>("DisableControls").Click();

            // Assert we can still read the values
            Assert.Equal("blah", textBox.Text);
            MainWindow.Get<Button>("DisableControls").Click();
        }

        void AllowActionsPossibleOnDisabledListControls()
        {
            SelectListControls();
            var comboBox = MainWindow.Get<ComboBox>("AComboBox");

            // Set Values
            comboBox.Select("Test2");

            MainWindow.Get<Button>("DisableControls").Click();

            // Assert we can still read the values
            Assert.Equal("Test2", comboBox.SelectedItem.Text);
            MainWindow.Get<Button>("DisableControls").Click();
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
            yield return WindowsFramework.Wpf;
        }
    }
}