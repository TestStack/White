using System.Windows.Automation;
using NUnit.Framework;
using White.Core.UIItems.Custom;
using White.Core.UIItems.WindowStripControls;

namespace White.Core.UIItems.Finders
{
    [TestFixture, NormalCategory]
    public class ControlTypeConditionTest
    {
        [Test]
        public void ControlTypeCondition()
        {
            Assert.AreEqual(ControlType.Button, new ControlTypeCondition(typeof (Button)).ControlType);
            Assert.AreEqual(ControlType.Pane, new ControlTypeCondition(typeof (TestCustomUIItem)).ControlType);
            Assert.AreEqual(ControlType.MenuBar, new ControlTypeCondition(typeof (MenuBar), Constants.WinFormFrameworkId).ControlType);
            Assert.AreEqual(ControlType.Menu, new ControlTypeCondition(typeof (MenuBar), Constants.WPFFrameworkId).ControlType);
        }
    }

    [ControlTypeMapping(CustomUIItemType.Pane)]
    public class TestCustomUIItem : CustomUIItem {}
}