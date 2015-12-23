using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Scrolling;

namespace TestStack.White.UnitTests.UIItems
{
    [TestFixture]
    public class PlatformSpecificItemAttributeTest
    {
        [Test]
        public void BaseTypeIsSpecified()
        {
            Assert.That(PlatformSpecificItemAttribute.BaseType(typeof(WPFComboBox)), Is.EqualTo(typeof(ComboBox)));
            Assert.That(PlatformSpecificItemAttribute.BaseType(typeof(HScrollBar)), Is.EqualTo(typeof(IHScrollBar)));
        }
    }
}