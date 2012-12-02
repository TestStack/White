using System;
using System.Reflection;
using System.Windows.Automation;
using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.ListBoxItems;
using White.Core.UIItems.WindowItems;
using White.Core.UITests.Testing;

//TODO: Check all operations and write tests possible on all disabled uiitem
namespace White.Core.UITests.Interceptors
{
    [TestFixture]
    public class DisabledControlsTest
    {
        private TestConfiguration configuration;
        private Window window;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            TestMode testMode = TestMode.Create(Environment.CommandLine);
            configuration = testMode.GetConfiguration(string.Empty, this);
        }

        [SetUp]
        public void SetUp()
        {
            window = configuration.Launch().GetWindow("Form1", configuration.WindowInitializeOption);
        }

        [Test, ExpectedException(typeof(ElementNotEnabledException))]
        public void DonotAllowActionOnDisabledControls()
        {
            var textBox = window.Get<TextBox>("textBox");
            window.Get<Button>("disableControls").Click();
            textBox.Text = "blah";
        }

        [Test]
        public void AllowActionsPossibleOnDisableControls()
        {
            var textBox = window.Get<TextBox>("textBox");
            var comboBox = window.Get<ComboBox>("komboBox");

            textBox.Text = "blah";
            comboBox.Select("Arundhati Roy");

            window.Get<Button>("disableControls").Click();

            Assert.AreEqual("blah", textBox.Text);
            Assert.AreEqual("Arundhati Roy", comboBox.SelectedItem.Text);
        }

        [TearDown]
        public void TearDown()
        {
            window.Focus();
            window.Close();
        }
    }
}