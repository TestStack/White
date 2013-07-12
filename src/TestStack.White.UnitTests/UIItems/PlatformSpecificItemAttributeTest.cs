using White.Core.UIItems;
using White.Core.UIItems.ListBoxItems;
using White.Core.UIItems.Scrolling;
using Xunit;

namespace TestStack.White.Core.UnitTests.UIItems
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