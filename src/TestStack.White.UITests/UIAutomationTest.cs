using System;
using System.Threading;
using System.Windows.Automation;
using NUnit.Framework;

namespace White.Core.UITests
{
    [TestFixture]
    public class UIAutomationTest
    {
        private Application application;

        [Ignore("Bug in caching framework for UIA")]
        public void Bug1()
        {
            application = new WinFormTestConfiguration(string.Empty).Launch();
            Thread.Sleep(1000);
            var propertyCondition = new PropertyCondition(AutomationElement.NameProperty, "Form1");
            AutomationElement element = AutomationElement.RootElement.FindFirst(TreeScope.Children, propertyCondition);
            AutomationElementCollection collection;
            var request = new CacheRequest();
            using (request.Activate())
                collection = element.FindAll(TreeScope.Subtree, Condition.TrueCondition);
            int cachedChildrenFoundFor = 0;
            foreach (AutomationElement automationElement in collection)
            {
                try
                {
                    AutomationElementCollection children = automationElement.CachedChildren;
                    cachedChildrenFoundFor++;
                }
                catch (InvalidOperationException) {}
            }
            Assert.AreNotEqual(0, cachedChildrenFoundFor, "Cached children not found for even one AutomationElement out of " + collection.Count + " elements");
        }

        [TearDown]
        public void TearDown()
        {
            application.Kill();
        }
    }
}