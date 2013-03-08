using System.Windows.Automation;
using NUnit.Framework;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;

namespace White.Core.UITests.UIItems.WindowItems
{
    [TestFixture, NormalCategory]
    public class UIItemContainerScenarioTest
    {
        //TODO: Create an MDI application for testing.
        [Test, Ignore]
        public void FindContainer()
        {
            Window window = Desktop.Instance.Windows().Find(obj => obj.Title.Contains("Microsoft Visual Studio"));
            if (window == null) return;

            window.MdiChild(SearchCriteria.ByControlType(ControlType.Pane).AndByText("UIItemContainerTest.cs"));
        }
    }
}