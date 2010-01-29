using NUnit.Framework;
using White.Core;
using White.Core.UIItems;
using White.Core.UIItems.Custom;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowStripControls;

namespace White.UnitTests.Core.UIItems.Finders
{
    [TestFixture, NormalCategory]
    public class ControlTypeConditionTest
    {
        [Test]
        public void ControlTypeCondition()
        {
            Assert.AreEqual("ControlType=button", SearchConditionFactory.CreateForControlType(typeof(Button)).ToString());
            Assert.AreEqual("ControlType=pane", SearchConditionFactory.CreateForControlType(typeof(TestCustomUIItem)).ToString());
            Assert.AreEqual("ControlType=menu bar", SearchConditionFactory.CreateForControlType(typeof(MenuBar), Constants.WinFormFrameworkId).ToString());
            Assert.AreEqual("ControlType=menu", SearchConditionFactory.CreateForControlType(typeof(MenuBar), Constants.WPFFrameworkId).ToString());
        }
    }

    [ControlTypeMapping(CustomUIItemType.Pane)]
    public class TestCustomUIItem : CustomUIItem {}
}