using System.Windows;
using System.Windows.Automation;
using TestStack.White.UIItems.Finders;
using Xunit;

namespace TestStack.White.UnitTests.UIItems.Finders
{
    public class SearchConditionFactoryTest
    {
        private readonly AutomationElement element;

        public SearchConditionFactoryTest()
        {
            element = AutomationElement.FromPoint(new Point(100, 100));
        }

        [Fact]
        public void Create()
        {
            Assert.Equal(true, SearchConditionFactory.CreateForControlType(element.Current.ControlType).AppliesTo(element));
            Assert.Equal(true, SearchConditionFactory.CreateForAutomationId(element.Current.AutomationId).AppliesTo(element));
            Assert.Equal(true, SearchConditionFactory.CreateForFrameworkId(element.Current.FrameworkId).AppliesTo(element));
            Assert.Equal(true, SearchConditionFactory.CreateForClassName(element.Current.ClassName).AppliesTo(element));
        }
    }
}