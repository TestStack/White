using System;
using System.Windows.Automation;
using NUnit.Framework;
using TestStack.White.Configuration;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UITests.ControlTests
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class ButtonTests : WhiteUITestBase
    {
        public ButtonTests(WindowsFramework framework)
            : base(framework) { }

        [Test]
        public void Click()
        {
            var button = MainWindow.Get<Button>("ButtonWithTooltip");
            button.Click();
            Assert.That(button.Text, Is.EqualTo("Button Clicked with Mouse"));
        }

        [Test]
        public void ThrowsWhenNotFound()
        {
            using (CoreAppXmlConfiguration.Instance.ApplyTemporarySetting(c => c.FindWindowTimeout = 500))
            {
                Assert.That(() => { MainWindow.Get<Button>(SearchCriteria.ByAutomationId("foo")); },
                    Throws.TypeOf<AutomationException>().With.
                    Message.EqualTo(String.Format("Failed to get (ControlType={0} or ControlType={1}),AutomationId=foo",
                        ControlType.Button.LocalizedControlType, ControlType.CheckBox.LocalizedControlType)));
            }
        }

        [Test]
        public void TestInvokePattern()
        {
            var button = MainWindow.Get<Button>("ButtonWithTooltip");
            button.Invoke();
            Assert.That(button.Text, Is.EqualTo("Clicked"));
        }
    }
}