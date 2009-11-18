using NUnit.Framework;
using White.Core.UIItems.ListBoxItems;
using White.Core.UIItems.Scrolling;

namespace White.Core.UIItems
{
    [TestFixture, NormalCategory]
    public class PlatformSpecificItemAttributeTest
    {
        [Test]
        public void BaseTypeIsSpecified()
        {
            Assert.AreEqual(typeof (ComboBox), PlatformSpecificItemAttribute.BaseType(typeof (WPFComboBox)));
            Assert.AreEqual(typeof (IHScrollBar), PlatformSpecificItemAttribute.BaseType(typeof (HScrollBar)));
        }
    }
}