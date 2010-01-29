using System.Windows.Automation;
using NUnit.Framework;
using White.Core.UIItems;
using White.UnitTests.Core.Testing;

namespace White.Core.AutomationElementSearch
{
    [TestFixture, WinFormCategory]
    public class RawAutomationElementFinderTest : ControlsActionTest
    {
        [Test]
        public void Descendant()
        {
            var listView = window.Get<ListView>("listView");
            var finder = new RawAutomationElementFinder(listView.AutomationElement);
            Assert.AreNotEqual(null, finder.Descendant(AutomationSearchCondition.ByControlType(ControlType.HeaderItem).OfName("Key")));
            Assert.AreEqual(null, finder.Descendant(AutomationSearchCondition.ByControlType(ControlType.Header).OfName("Key")));
        }

    }
}