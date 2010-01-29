using NUnit.Framework;
using White.Core;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.UnitTests.Core.Testing;

namespace White.UnitTests.Core.UIItems.Finders
{
    [TestFixture, Category("Normal")]
    public class SearchCriteriaTest
    {
        [Test]
        public void IsIndexed()
        {
            Assert.AreEqual(false, SearchCriteria.ByAutomationId("").IsIndexed);
            Assert.AreEqual(true, SearchCriteria.Indexed(1).IsIndexed);
            Assert.AreEqual(true, SearchCriteria.Indexed(0).IsIndexed);
        }

        [Test]
        public void Equals()
        {
            Assert.AreEqual(SearchCriteria.ByAutomationId("foo"), SearchCriteria.ByAutomationId("foo"));
            Assert.AreNotEqual(SearchCriteria.ByText("foo"), SearchCriteria.ByAutomationId("foo"));
            Assert.AreEqual(SearchCriteria.ByFramework(Constants.Win32FrameworkId), SearchCriteria.ByFramework(Constants.Win32FrameworkId));
            Assert.AreNotEqual(SearchCriteria.ByFramework(Constants.WinFormFrameworkId), SearchCriteria.ByFramework(Constants.Win32FrameworkId));
        }
    }

    [TestFixture, Category("Normal")]
    public class SearchCriteriaAppliesToTest : ControlsActionTest
    {
        [Test]
        public void Applies()
        {
            SearchCriteria searchCriteria = SearchCriteria.ByAutomationId("buton").AndControlType(typeof (Button));
            IUIItem button = window.Get(searchCriteria);
            Assert.AreEqual(true, searchCriteria.AppliesTo(button.AutomationElement));
            button = window.Get<Button>("launchModal");
            Assert.AreEqual(false, searchCriteria.AppliesTo(button.AutomationElement));
        }
    }
}