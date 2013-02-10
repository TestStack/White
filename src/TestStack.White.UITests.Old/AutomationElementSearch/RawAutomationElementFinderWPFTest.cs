using System.Windows.Automation;
using NUnit.Framework;
using White.Core.UIItems.Finders;
using White.Core.UITests.Testing;

namespace White.Core.UITests.AutomationElementSearch
{
    [TestFixture, WPFCategory]
    public class RawAutomationElementFinderWPFTest : ControlsActionTest
    {
        [Test]
        public void FindTextBlock()
        {
            AutomationElement element = Window.GetElement(SearchCriteria.ByAutomationId("newBlock"));
            Assert.AreNotEqual(null, element);
        }        
    }
}