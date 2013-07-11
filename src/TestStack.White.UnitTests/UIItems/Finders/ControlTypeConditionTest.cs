using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowStripControls;
using Xunit;

namespace White.Core.UnitTests.UIItems.Finders
{
    public class ControlTypeConditionTest
    {
        [Fact]
        public void ControlTypeCondition()
        {
            Assert.Equal("(ControlType=button or ControlType=check box)", SearchConditionFactory.CreateForControlType(typeof (Button), WindowsFramework.Wpf).ToString());
            Assert.Equal("ControlType=pane", SearchConditionFactory.CreateForControlType(typeof(TestCustomUIItem), WindowsFramework.Wpf).ToString());
            Assert.Equal("ControlType=menu bar", SearchConditionFactory.CreateForControlType(typeof(MenuBar), WindowsFramework.WinForms).ToString());
            Assert.Equal("ControlType=menu", SearchConditionFactory.CreateForControlType(typeof (MenuBar), WindowsFramework.Wpf).ToString());
        }
    }
}