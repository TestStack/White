using NUnit.Framework;
using System;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Configuration;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.AutomationElementSearch
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class RawAutomationElementFinderTests : WhiteUITestBase
    {
        private IDisposable cleanup;

        public RawAutomationElementFinderTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            cleanup = CoreConfigurationLocator.Get().ApplyTemporarySettings(c =>
            {
                c.RawElementBasedSearch = true;
                c.MaxElementSearchDepth = 2;
            });
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            cleanup.Dispose();
        }

        [Test]
        public void DescendantTest()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListView");
                var finder = new RawAutomationElementFinder(listView.AutomationElement);
                Assert.That(finder.Descendant(AutomationSearchCondition.ByControlType(ControlType.HeaderItem).WithName("Key")), Is.Not.Null);
                Assert.That(finder.Descendant(AutomationSearchCondition.ByControlType(ControlType.Header).WithName("Key")), Is.Null);
            }
        }
    }
}