using System.Collections.Generic;
using White.Core.UIItems;
using White.Core.UIItems.ListBoxItems;
using Xunit;

namespace TestStack.White.UITests.Interceptors
{
    public class ScrollInterceptorTest : WhiteTestBase
    {
        public void GetItemOutsideWindowButWithoutScroll()
        {
            using (var window = StartScenario("OpenFormWithoutScrollAndItemOutside", "FormWithoutScrollAndItemOutside"))
            {
                var listBox = window.Get<ListBox>("ListBox");
                Assert.NotEqual(null, listBox);
                Assert.Equal(0, listBox.Items.Count);
            }
        }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            GetItemOutsideWindowButWithoutScroll();
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
            yield return WindowsFramework.Wpf;
        }
    }
}