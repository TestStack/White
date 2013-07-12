using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Configuration;
using TestStack.White.UIItems;
using Xunit;

namespace TestStack.White.UITests.AutomationElementSearch
{
    public class RawAutomationElementFinderTest : WhiteTestBase
    {
        public RawAutomationElementFinderTest()
        {
            CoreAppXmlConfiguration.Instance.RawElementBasedSearch = true;
            CoreAppXmlConfiguration.Instance.MaxElementSearchDepth = 2;
        }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(Descendant);
        }

        public void Descendant()
        {
            var window = StartScenario("OpenListView", "ListViewWindow");
            var listView = window.Get<ListView>("ListView");
            var finder = new RawAutomationElementFinder(listView.AutomationElement);
            Assert.NotEqual(null, finder.Descendant(AutomationSearchCondition.ByControlType(ControlType.HeaderItem).OfName("Key")));
            Assert.Equal(null, finder.Descendant(AutomationSearchCondition.ByControlType(ControlType.Header).OfName("Key")));
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
            yield return WindowsFramework.Wpf;
        }

        public void Dispose()
        {
            CoreAppXmlConfiguration.Instance.RawElementBasedSearch = false;
        }
    }
}