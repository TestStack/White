using NUnit.Framework;
using System.Linq;
using System.Windows.Automation;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UITests.Scenarios
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class GetMultipleTests : WhiteUITestBase
    {
        public GetMultipleTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [Test]
        public void GetControlBasedOnIndexTest()
        {
            using (var window = StartScenario("GetMultipleButton", "GetMultiple"))
            {
                var button = window.Get<Button>(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "Button").AndIndex(0));
                Assert.That(button, Is.Not.Null);

                var expected = Framework == WindowsFramework.Wpf ?
                    "Failed to get ControlType=edit,AutomationElementIdentifiers.NameProperty=Button,Index=4" :
                    "Failed to get (ControlType=edit or ControlType=document),AutomationElementIdentifiers.NameProperty=Button,Index=4";

                Assert.That(() => { MainWindow.Get<TextBox>(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "Button").AndIndex(4)); },
                    Throws.TypeOf<AutomationException>().With.
                    Message.EqualTo(expected));
            }
        }

        [Test]
        [Category("NeedsFix")]
        [Ignore("NeedsFix")]
        public void GetMultipleButtonsTest()
        {
            MainWindow.Get<Button>("GetMultipleButton").Click();
            var window = MainWindow.ModalWindow("GetMultiple");

            try
            {
                var buttons = window.GetMultiple(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "Button")).OfType<Button>().ToList();
                Assert.That(buttons, Has.Count.EqualTo(3));

                if (Framework == WindowsFramework.Wpf)
                {
                    buttons = window.GetMultiple(SearchCriteria.ByAutomationId("Test")).OfType<Button>().ToList();
                    Assert.That(buttons, Has.Count.EqualTo(3));
                }

                var checkboxes = window.GetMultiple(SearchCriteria.ByControlType(ControlType.CheckBox)).OfType<CheckBox>().ToList();
                Assert.That(checkboxes, Has.Count.EqualTo(3));

                checkboxes = window.GetMultiple(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "Checkbox")).OfType<CheckBox>().ToList();
                Assert.That(checkboxes, Has.Count.EqualTo(3));

                if (Framework == WindowsFramework.Wpf)
                {
                    checkboxes = window.GetMultiple(SearchCriteria.ByAutomationId("Test2")).OfType<CheckBox>().ToList();
                    Assert.That(checkboxes, Has.Count.EqualTo(3));
                }

                if (Framework == WindowsFramework.Wpf)
                {
                    var customControls = window.GetMultiple(SearchCriteria.ByClassName("CustomItem")).ToList();
                    Assert.That(customControls, Has.Count.EqualTo(3));
                }
            }
            finally
            {
                window.Close();
            }
        }
    }
}