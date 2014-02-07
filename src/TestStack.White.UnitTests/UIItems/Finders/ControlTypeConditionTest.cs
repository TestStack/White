using System.Windows.Automation;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowStripControls;
using Xunit;

namespace TestStack.White.UnitTests.UIItems.Finders
{
    public class ControlTypeConditionTest
    {
        [Fact]
        public void ControlTypeCondition()
        {
            Assert.Equal(string.Format("(ControlType={0} or ControlType={1})",
                ControlType.Button.LocalizedControlType,
                ControlType.CheckBox.LocalizedControlType),
                SearchConditionFactory.CreateForControlType(typeof (Button), WindowsFramework.Wpf).ToString());
            Assert.Equal(string.Format("ControlType={0}", ControlType.Pane.LocalizedControlType),
                SearchConditionFactory.CreateForControlType(typeof (TestCustomUIItem), WindowsFramework.Wpf).ToString());
            Assert.Equal(string.Format("ControlType={0}", ControlType.MenuBar.LocalizedControlType),
                SearchConditionFactory.CreateForControlType(typeof (MenuBar), WindowsFramework.WinForms).ToString());
            Assert.Equal(string.Format("ControlType={0}", ControlType.Menu.LocalizedControlType),
                SearchConditionFactory.CreateForControlType(typeof (MenuBar), WindowsFramework.Wpf).ToString());
        }
    }
}