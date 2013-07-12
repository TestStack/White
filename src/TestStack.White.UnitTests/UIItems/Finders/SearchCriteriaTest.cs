using System.Windows.Automation;
using White.Core;
using White.Core.UIItems.Finders;
using Xunit;

namespace TestStack.White.Core.UnitTests.UIItems.Finders
{
    public class SearchCriteriaTest
    {
        [Fact]
        public void IsIndexed()
        {
            Assert.Equal(false, SearchCriteria.ByAutomationId("").IsIndexed);
            Assert.Equal(true, SearchCriteria.Indexed(1).IsIndexed);
            Assert.Equal(true, SearchCriteria.Indexed(0).IsIndexed);
        }

        [Fact]
        public void Merge()
        {
            Assert.Equal(SearchCriteria.ByAutomationId("foo").Merge(SearchCriteria.ByControlType(ControlType.Button)),
                            SearchCriteria.ByAutomationId("foo").AndControlType(ControlType.Button));
            Assert.Equal(SearchCriteria.ByAutomationId("foo").Merge(SearchCriteria.ByControlType(ControlType.Button).NotIdentifiedByText("bar")),
                            SearchCriteria.ByAutomationId("foo").AndControlType(ControlType.Button).NotIdentifiedByText("bar"));
        }

        [Fact]
        public void Equals()
        {
            Assert.Equal(SearchCriteria.ByAutomationId("foo"), SearchCriteria.ByAutomationId("foo"));
            Assert.NotEqual(SearchCriteria.ByText("foo"), SearchCriteria.ByAutomationId("foo"));
            Assert.Equal(SearchCriteria.ByFramework(Constants.Win32FrameworkId), SearchCriteria.ByFramework(Constants.Win32FrameworkId));
            Assert.NotEqual(SearchCriteria.ByFramework(Constants.WinFormFrameworkId), SearchCriteria.ByFramework(Constants.Win32FrameworkId));
            Assert.Equal(SearchCriteria.ByAutomationId("foo").AndByText("bar"), SearchCriteria.ByAutomationId("foo").AndByText("bar"));
            Assert.Equal(SearchCriteria.ByText("bar").AndAutomationId("foo"), SearchCriteria.ByAutomationId("foo").AndByText("bar"));
            //ByNativePropertyTests...
            Assert.Equal(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "blah"), SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "blah"));
            Assert.NotEqual(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "blah"), SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "blah1"));
            Assert.Equal(SearchCriteria.ByNativeProperty(AutomationElement.IsControlElementProperty, true), SearchCriteria.ByNativeProperty(AutomationElement.IsControlElementProperty, true));
            Assert.NotEqual(SearchCriteria.ByNativeProperty(AutomationElement.IsControlElementProperty, true), SearchCriteria.ByNativeProperty(AutomationElement.IsControlElementProperty, false));
            Assert.NotEqual(SearchCriteria.ByNativeProperty(AutomationElement.IsControlElementProperty, true), SearchCriteria.ByNativeProperty(AutomationElement.IsDockPatternAvailableProperty, true));
        }

        [Fact]
        public void TestToString()
        {
            Assert.Equal("AutomationId=foo,Name=bar", SearchCriteria.ByText("bar").AndAutomationId("foo").ToString());
            Assert.Equal("AutomationId=foo,Name=bar,Index=1", SearchCriteria.ByText("bar").AndAutomationId("foo").AndIndex(1).ToString());
            //ByNativePropertyTests...
            Assert.Equal("AutomationElementIdentifiers.NameProperty=blah", SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "blah").ToString());
            Assert.Equal("AutomationElementIdentifiers.IsControlElementProperty=True", SearchCriteria.ByNativeProperty(AutomationElement.IsControlElementProperty, true).ToString());
        }
    }
}