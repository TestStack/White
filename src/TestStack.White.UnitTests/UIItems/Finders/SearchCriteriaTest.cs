using System.Windows.Automation;
using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UnitTests.UIItems.Finders
{
    [TestFixture]
    public class SearchCriteriaTest
    {
        [Test]
        public void IsIndexed()
        {
            Assert.That(SearchCriteria.ByAutomationId("").IsIndexed, Is.False);
            Assert.That(SearchCriteria.Indexed(1).IsIndexed, Is.True);
            Assert.That(SearchCriteria.Indexed(0).IsIndexed, Is.True);
        }

        [Test]
        public void Merge()
        {
            Assert.That(SearchCriteria.ByAutomationId("foo").Merge(SearchCriteria.ByControlType(ControlType.Button)),
                Is.EqualTo(SearchCriteria.ByAutomationId("foo").AndControlType(ControlType.Button)));
            Assert.That(SearchCriteria.ByAutomationId("foo").Merge(SearchCriteria.ByControlType(ControlType.Button).NotIdentifiedByText("bar")),
                Is.EqualTo(SearchCriteria.ByAutomationId("foo").AndControlType(ControlType.Button).NotIdentifiedByText("bar")));
        }

        [Test]
        public void EqualsTests()
        {
            Assert.That(SearchCriteria.ByAutomationId("foo"), Is.EqualTo(SearchCriteria.ByAutomationId("foo")));
            Assert.That(SearchCriteria.ByText("foo"), Is.Not.EqualTo(SearchCriteria.ByAutomationId("foo")));
            Assert.That(SearchCriteria.ByFramework(WindowsFramework.Win32.FrameworkId()), Is.EqualTo(SearchCriteria.ByFramework(WindowsFramework.Win32.FrameworkId())));
            Assert.That(SearchCriteria.ByFramework(WindowsFramework.WinForms.FrameworkId()), Is.Not.EqualTo(SearchCriteria.ByFramework(WindowsFramework.Win32.FrameworkId())));
            Assert.That(SearchCriteria.ByAutomationId("foo").AndByText("bar"), Is.EqualTo(SearchCriteria.ByAutomationId("foo").AndByText("bar")));
            Assert.That(SearchCriteria.ByAutomationId("foo").AndByText("bar"), Is.EqualTo(SearchCriteria.ByText("bar").AndAutomationId("foo")));
            //ByNativePropertyTests...
            Assert.That(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "blah"), Is.EqualTo(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "blah")));
            Assert.That(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "blah"), Is.Not.EqualTo(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "blah1")));
            Assert.That(SearchCriteria.ByNativeProperty(AutomationElement.IsControlElementProperty, true), Is.EqualTo(SearchCriteria.ByNativeProperty(AutomationElement.IsControlElementProperty, true)));
            Assert.That(SearchCriteria.ByNativeProperty(AutomationElement.IsControlElementProperty, true), Is.Not.EqualTo(SearchCriteria.ByNativeProperty(AutomationElement.IsControlElementProperty, false)));
            Assert.That(SearchCriteria.ByNativeProperty(AutomationElement.IsControlElementProperty, true), Is.Not.EqualTo(SearchCriteria.ByNativeProperty(AutomationElement.IsDockPatternAvailableProperty, true)));
        }

        [Test]
        public void TestToString()
        {
            Assert.That(SearchCriteria.ByText("bar").AndAutomationId("foo").ToString(), Is.EqualTo("AutomationId=foo,Name=bar"));
            Assert.That(SearchCriteria.ByText("bar").AndAutomationId("foo").AndIndex(1).ToString(), Is.EqualTo("AutomationId=foo,Name=bar,Index=1"));
            //ByNativePropertyTests...
            Assert.That(SearchCriteria.ByNativeProperty(AutomationElement.NameProperty, "blah").ToString(), Is.EqualTo("AutomationElementIdentifiers.NameProperty=blah"));
            Assert.That(SearchCriteria.ByNativeProperty(AutomationElement.IsControlElementProperty, true).ToString(), Is.EqualTo("AutomationElementIdentifiers.IsControlElementProperty=True"));
        }
    }
}