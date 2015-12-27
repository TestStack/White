using NUnit.Framework;
using System;
using TestStack.White.UIItems;
using TestStack.White.Utility;

namespace TestStack.White.UITests.ControlTests.InputControls
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class PasswordTextBoxTests : WhiteUITestBase
    {
        public PasswordTextBoxTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectInputControls();
        }

        [Test]
        public void CannotGetTextFromPasswordTest()
        {
            var textBox = MainWindow.Get<TextBox>("PasswordBox");
            textBox.BulkText = "foobar";

            Assert.That(() =>
            {
                // ReSharper disable once UnusedVariable
                var text = textBox.Text;
            }, Throws.TypeOf<WhiteException>().With.
                Message.EqualTo("Text cannot be retrieved from textbox which has secret text (e.g. password) stored in it"));
        }

        [Test]
        public void GetPasswordValueWhenTextBoxIsNotPasswordFieldTest()
        {
            if (Framework == WindowsFramework.Wpf)
            {
                Assert.Ignore("Do not run for WPF");
            }
            var textBox = MainWindow.Get<TextBox>("PasswordBox");
            textBox.BulkText = "foobar";
            MainWindow.Get<Button>("UnmaskPasswordButton").Click();
            textBox = MainWindow.Get<TextBox>("PasswordBox");
            string text = Retry.For(() => textBox.Text, TimeSpan.FromSeconds(2));
            Assert.That(text, Is.EqualTo("foobar"));
        }
    }
}