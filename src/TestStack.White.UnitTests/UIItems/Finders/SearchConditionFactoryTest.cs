using NUnit.Framework;
using System.Windows;
using System.Windows.Automation;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UnitTests.UIItems.Finders
{
    [TestFixture]
    public class SearchConditionFactoryTest
    {
        private readonly AutomationElement element;

        public SearchConditionFactoryTest()
        {
            element = AutomationElement.FromPoint(new Point(100, 100));
        }

        [Test]
        public void Create()
        {
            Assert.That(SearchConditionFactory.CreateForControlType(element.Current.ControlType).AppliesTo(element), Is.True);
            Assert.That(SearchConditionFactory.CreateForAutomationId(element.Current.AutomationId).AppliesTo(element), Is.True);
            Assert.That(SearchConditionFactory.CreateForFrameworkId(element.Current.FrameworkId).AppliesTo(element), Is.True);
            Assert.That(SearchConditionFactory.CreateForClassName(element.Current.ClassName).AppliesTo(element), Is.True);
        }
    }
}