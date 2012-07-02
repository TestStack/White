using NUnit.Framework;

using White.Core.UIItems;
using White.Core.UIItems.Custom;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowStripControls;
using System.Windows.Automation;

namespace White.Core.UnitTests.UIItems.Finders
{
    [TestFixture]
    public class NativePropertyConditionTest
    {
        [Test]
        public void NativePropertyCondition()
        {
            SearchCondition test = SearchConditionFactory.CreateForNativeProperty(AutomationElement.IsControlElementProperty, true);
            PropertyCondition expected;
            expected = new PropertyCondition(AutomationElement.IsControlElementProperty, true);
            Assert.AreEqual((bool)expected.Value,(bool)((PropertyCondition)test.AutomationCondition).Value);
            Assert.AreEqual(expected.Property.ProgrammaticName, ((PropertyCondition)test.AutomationCondition).Property.ProgrammaticName);
            expected = new PropertyCondition(AutomationElement.NameProperty, "hello");
            test = SearchConditionFactory.CreateForNativeProperty(AutomationElement.NameProperty, "hello");
            Assert.AreEqual((string)expected.Value, (string)((PropertyCondition)test.AutomationCondition).Value);
            Assert.AreEqual(expected.Property.ProgrammaticName, ((PropertyCondition)test.AutomationCondition).Property.ProgrammaticName);
        }
    }
}
