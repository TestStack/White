using System.Windows.Automation;
using NUnit.Framework;
using White.Core;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.UnitTests.Core.Testing;

namespace White.UnitTests.Core.UIItems.Finders
{
    [TestFixture, NormalCategory]
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
        public void Merge()
        {
            Assert.AreEqual(SearchCriteria.ByAutomationId("foo").Merge(SearchCriteria.ByControlType(ControlType.Button)), SearchCriteria.ByAutomationId("foo").AndControlType(ControlType.Button));
            Assert.AreEqual(SearchCriteria.ByAutomationId("foo").Merge(SearchCriteria.ByControlType(ControlType.Button).NotIdentifiedByText("bar")), SearchCriteria.ByAutomationId("foo").AndControlType(ControlType.Button).NotIdentifiedByText("bar"));
        }

        [Test]
        public void Equals()
        {
            Assert.AreEqual(SearchCriteria.ByAutomationId("foo"), SearchCriteria.ByAutomationId("foo"));
            Assert.AreNotEqual(SearchCriteria.ByText("foo"), SearchCriteria.ByAutomationId("foo"));
            Assert.AreEqual(SearchCriteria.ByFramework(Constants.Win32FrameworkId), SearchCriteria.ByFramework(Constants.Win32FrameworkId));
            Assert.AreNotEqual(SearchCriteria.ByFramework(Constants.WinFormFrameworkId), SearchCriteria.ByFramework(Constants.Win32FrameworkId));
            Assert.AreEqual(SearchCriteria.ByAutomationId("foo").AndByText("bar"), SearchCriteria.ByAutomationId("foo").AndByText("bar"));
            Assert.AreEqual(SearchCriteria.ByText("bar").AndAutomationId("foo"), SearchCriteria.ByAutomationId("foo").AndByText("bar"));
        }
    }

    [TestFixture, NormalCategory]
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