using System;
using System.Collections.Generic;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Custom;
using TestStack.White.UIItems.WindowItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests
{
    public class CustomUIItemTest : WhiteTestBase
    {
        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            // ReSharper disable AccessToDisposedClosure
            using (var window = StartScenario("CustomUIItemScenario", "CustomUIItemScenario"))
            {
                RunTest(() => FindCustomItem(window));
                RunTest(() => NoDateUIItemMappingDefined(window));
            }
        }

        void FindCustomItem(Window window)
        {
            var myDateUIItem = window.Get<MyDateUIItem>("DateOfBirth");
            Assert.NotEqual(null, myDateUIItem);
            myDateUIItem.EnterDate(DateTime.Today);
        }

        void NoDateUIItemMappingDefined(Window window)
        {
            Assert.Throws<CustomUIItemException>(()=>window.Get<MyDateUIItemWithoutMappingDefined>("DateOfBirth"));
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}