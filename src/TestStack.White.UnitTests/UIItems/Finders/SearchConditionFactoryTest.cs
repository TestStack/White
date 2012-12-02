using System.Windows;
using System.Windows.Automation;
using NUnit.Framework;
using White.Core.UIItems.Finders;

namespace White.Core.UnitTests.UIItems.Finders
{
    [TestFixture]
    public class SearchConditionFactoryTest
    {
        private AutomationElement element;

        [TestFixtureSetUp]
        public void SetUp()
        {
            element = AutomationElement.FromPoint(new Point(100, 100));
        }

        [Test]
        public void Create()
        {
            Assert.AreEqual(true, SearchConditionFactory.CreateForControlType(element.Current.ControlType).AppliesTo(element));
            Assert.AreEqual(true, SearchConditionFactory.CreateForAutomationId(element.Current.AutomationId).AppliesTo(element));
            Assert.AreEqual(true, SearchConditionFactory.CreateForFrameworkId(element.Current.FrameworkId).AppliesTo(element));
            Assert.AreEqual(true, SearchConditionFactory.CreateForClassName(element.Current.ClassName).AppliesTo(element));
        }
    }
}