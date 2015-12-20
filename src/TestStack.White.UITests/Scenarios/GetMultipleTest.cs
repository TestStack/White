using System.Linq;
using System.Windows.Automation;
using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UITests.Scenarios
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class GetMultipleTest : WhiteUITestBase
    {
        public GetMultipleTest(WindowsFramework framework) : base(framework)
        {
        }

        [Test]
        public void GetControlBasedOnIndex()
        {
            using (var window = StartScenario("GetMultipleButton", "GetMultiple"))
            {
                var button = window.Get<Button>(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "Button").AndIndex(0));
                Assert.NotNull(button);

                var exception = Assert.Throws<AutomationException>(() => MainWindow.Get<TextBox>(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "Button").AndIndex(4)));
                var expected = Framework == WindowsFramework.Wpf?
                    "Failed to get ControlType=edit,AutomationElementIdentifiers.NameProperty=Button,Index=4":
                    "Failed to get (ControlType=edit or ControlType=document),AutomationElementIdentifiers.NameProperty=Button,Index=4";
                Assert.That(expected, Is.EqualTo(exception.Message));
            }
        }

        [Test]
        public void GetMultipleButtons()
        {
            MainWindow.Get<Button>("GetMultipleButton").Click();
            var window = MainWindow.ModalWindow("GetMultiple");

            try
            {
                var buttons = window.GetMultiple(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "Button")).OfType<Button>();
                Assert.That(3, Is.EqualTo(buttons.Count()));

                if (Framework == WindowsFramework.Wpf)
                {
                    buttons = window.GetMultiple(SearchCriteria.ByAutomationId("Test")).OfType<Button>();
                    Assert.That(3, Is.EqualTo(buttons.Count()));
                }

                var checkboxes = window.GetMultiple(SearchCriteria.ByControlType(ControlType.CheckBox)).OfType<CheckBox>();
                Assert.That(3, Is.EqualTo(checkboxes.Count()));

                checkboxes = window.GetMultiple(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "Checkbox")).OfType<CheckBox>();
                Assert.That(3, Is.EqualTo(checkboxes.Count()));

                if (Framework == WindowsFramework.Wpf)
                {
                    checkboxes = window.GetMultiple(SearchCriteria.ByAutomationId("Test2")).OfType<CheckBox>();
                    Assert.That(3, Is.EqualTo(checkboxes.Count()));
                }

                if (Framework == WindowsFramework.Wpf)
                {
                    var customControls = window.GetMultiple(SearchCriteria.ByClassName("CustomItem"));

                    Assert.That(3, Is.EqualTo(customControls.Length));
                }
            }
            finally
            {
                window.Close();
            }
        }
    }
}