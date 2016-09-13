using NUnit.Framework;
using System;
using System.Windows.Automation;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.Utility;

namespace TestStack.White.UITests.Interceptors
{
    //TODO: Check all operations and write tests possible on all disabled uiitem
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class DisabledControlsTests : WhiteUITestBase
    {
        public DisabledControlsTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [Test]
        public void DoNotAllowActionOnDisabledControlsTest()
        {
            SelectInputControls();
            var textBox = MainWindow.Get<TextBox>("TextBox");
            MainWindow.Get<Button>("DisableControls").Click();
            Retry.For(() => !textBox.Enabled, TimeSpan.FromSeconds(2));
            Assert.That(() => { textBox.Text = "blah"; }, Throws.TypeOf<ElementNotEnabledException>());
            MainWindow.Get<Button>("DisableControls").Click();
        }

        [Test]
        public void AllowActionsPossibleOnDisabledInputControlsTest()
        {
            SelectInputControls();
            var textBox = MainWindow.Get<TextBox>("TextBox");

            // Set Values
            textBox.Text = "blah";

            MainWindow.Get<Button>("DisableControls").Click();

            // Assert we can still read the values
            Assert.That(textBox.Text, Is.EqualTo("blah"));
            MainWindow.Get<Button>("DisableControls").Click();
        }

        [Test]
        public void AllowActionsPossibleOnDisabledListControlsTest()
        {
            SelectListControls();
            var comboBox = MainWindow.Get<ComboBox>("AComboBox");

            // Set Values
            comboBox.Select("Test2");

            MainWindow.Get<Button>("DisableControls").Click();

            // Assert we can still read the values
            Assert.That(comboBox.SelectedItem.Text, Is.EqualTo("Test2"));
            MainWindow.Get<Button>("DisableControls").Click();
        }
    }
}