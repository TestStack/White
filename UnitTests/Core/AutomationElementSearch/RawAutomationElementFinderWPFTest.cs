using System.Windows.Automation;
using NUnit.Framework;
using White.Core.UIItems.Finders;
using White.UnitTests.Core.Testing;

namespace White.Core.AutomationElementSearch
{
    [TestFixture, Category("WPF")]
    public class RawAutomationElementFinderWPFTest : ControlsActionTest
    {
        [Test]
        public void FindTextBlock()
        {
            AutomationElement element = window.GetElement(SearchCriteria.ByAutomationId("newBlock"));
            Assert.AreNotEqual(null, element);
        }        
    }
}