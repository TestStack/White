using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;
using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.Finders;

namespace TestStack.White.UITests.Scenarios
{
    public class GetMultipleTest : WhiteTestBase
    {
        protected override void RunTest(WindowsFramework framework)
        {
            RunTest(() => GetMultipleButtons(framework));
        }

        private void GetMultipleButtons(WindowsFramework framework)
        {
            MainWindow.Get<Button>("GetMultipleButton").Click();
            var window = MainWindow.ModalWindow("GetMultiple");

            try
            {
                var buttons = window.GetMultiple(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "Button")).OfType<Button>();
                Assert.AreEqual(3, buttons.Count());

                if (framework == WindowsFramework.Wpf)
                {
                    buttons = window.GetMultiple(SearchCriteria.ByAutomationId("Test")).OfType<Button>();
                    Assert.AreEqual(3, buttons.Count());
                }

                var checkboxes = window.GetMultiple(SearchCriteria.ByControlType(ControlType.CheckBox)).OfType<CheckBox>();
                Assert.AreEqual(3, checkboxes.Count());

                checkboxes = window.GetMultiple(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "Checkbox")).OfType<CheckBox>();
                Assert.AreEqual(3, checkboxes.Count());

                if (framework == WindowsFramework.Wpf)
                {
                    checkboxes = window.GetMultiple(SearchCriteria.ByAutomationId("Test2")).OfType<CheckBox>();
                    Assert.AreEqual(3, checkboxes.Count());
                }
            }
            finally
            {
                window.Close();
            }
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}