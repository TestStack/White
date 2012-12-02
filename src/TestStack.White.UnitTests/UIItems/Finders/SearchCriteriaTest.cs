using System.Windows.Automation;
using NUnit.Framework;
using White.Core.UIItems.Finders;

namespace White.Core.UnitTests.UIItems.Finders
{
    [TestFixture]
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
            Assert.AreEqual(SearchCriteria.ByAutomationId("foo").Merge(SearchCriteria.ByControlType(ControlType.Button)),
                            SearchCriteria.ByAutomationId("foo").AndControlType(ControlType.Button));
            Assert.AreEqual(SearchCriteria.ByAutomationId("foo").Merge(SearchCriteria.ByControlType(ControlType.Button).NotIdentifiedByText("bar")),
                            SearchCriteria.ByAutomationId("foo").AndControlType(ControlType.Button).NotIdentifiedByText("bar"));
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
            //ByNativePropertyTests...
            Assert.AreEqual(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "blah"), SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "blah"));
            Assert.AreNotEqual(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "blah"), SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "blah1"));
            Assert.AreEqual(SearchCriteria.ByNativeProperty(AutomationElement.IsControlElementProperty, true), SearchCriteria.ByNativeProperty(AutomationElement.IsControlElementProperty, true));
            Assert.AreNotEqual(SearchCriteria.ByNativeProperty(AutomationElement.IsControlElementProperty, true), SearchCriteria.ByNativeProperty(AutomationElement.IsControlElementProperty, false));
            Assert.AreNotEqual(SearchCriteria.ByNativeProperty(AutomationElement.IsControlElementProperty, true), SearchCriteria.ByNativeProperty(AutomationElement.IsDockPatternAvailableProperty, true));
        }

        [Test]
        public void TestToString()
        {
            Assert.AreEqual("AutomationId=foo,Name=bar", SearchCriteria.ByText("bar").AndAutomationId("foo").ToString());
            Assert.AreEqual("AutomationId=foo,Name=bar,Index=1", SearchCriteria.ByText("bar").AndAutomationId("foo").AndIndex(1).ToString());
            //ByNativePropertyTests...
            Assert.AreEqual("AutomationElementIdentifiers.NameProperty=blah", SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "blah").ToString());
            Assert.AreEqual("AutomationElementIdentifiers.IsControlElementProperty=True", SearchCriteria.ByNativeProperty(AutomationElement.IsControlElementProperty, true).ToString());
        }
    }
}