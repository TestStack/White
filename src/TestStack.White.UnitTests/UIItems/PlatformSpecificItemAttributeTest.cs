using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Scrolling;
using Xunit;

namespace TestStack.White.UnitTests.UIItems
{
    public class PlatformSpecificItemAttributeTest
    {
        [Fact]
        public void BaseTypeIsSpecified()
        {
            Assert.Equal(typeof (ComboBox), PlatformSpecificItemAttribute.BaseType(typeof (WPFComboBox)));
            Assert.Equal(typeof (IHScrollBar), PlatformSpecificItemAttribute.BaseType(typeof (HScrollBar)));
        }
    }
}