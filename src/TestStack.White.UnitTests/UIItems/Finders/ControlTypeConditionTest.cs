using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.Custom;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowStripControls;

namespace White.Core.UnitTests.UIItems.Finders
{
    [TestFixture]
    public class ControlTypeConditionTest
    {
        [Test]
        public void ControlTypeCondition()
        {
            Assert.AreEqual("ControlType=button", SearchConditionFactory.CreateForControlType(typeof (Button), WindowsFramework.Wpf).ToString());
            Assert.AreEqual("ControlType=pane", SearchConditionFactory.CreateForControlType(typeof(TestCustomUIItem), WindowsFramework.Wpf).ToString());
            Assert.AreEqual("ControlType=menu bar", SearchConditionFactory.CreateForControlType(typeof(MenuBar), WindowsFramework.WinForms).ToString());
            Assert.AreEqual("ControlType=menu", SearchConditionFactory.CreateForControlType(typeof (MenuBar), WindowsFramework.Wpf).ToString());
        }
    }

    [ControlTypeMapping(CustomUIItemType.Pane)]
    public class TestCustomUIItem : CustomUIItem
    {
    }
}