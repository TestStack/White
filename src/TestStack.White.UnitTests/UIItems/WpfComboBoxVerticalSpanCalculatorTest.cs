using System.Windows;
using White.Core;
using White.Core.UIItems.ListBoxItems;
using Xunit;

namespace TestStack.White.Core.UnitTests.UIItems
{
    public class WpfComboBoxVerticalSpanCalculatorTest
    {
        [Fact]
        public void Calculate()
        {
            var calculator = new WPFComboBoxVerticalSpanCalculator(Rectangle(0), Rectangle(10), Rectangle(100), 60);
            VerticalSpan verticalSpan = calculator.VerticalSpan;
            Assert.Equal(10, verticalSpan.Start);
            Assert.Equal(70, verticalSpan.End);
        }

        [Fact]
        public void CalculateWhenListItemsDropUp()
        {
            var calculator = new WPFComboBoxVerticalSpanCalculator(Rectangle(70), Rectangle(10), Rectangle(100), 60);
            VerticalSpan verticalSpan = calculator.VerticalSpan;
            Assert.Equal(10, verticalSpan.Start);
            Assert.Equal(70, verticalSpan.End);
        }

        private static Rect Rectangle(int y)
        {
            return new Rect(10, y, 10, 10);
        }
    }
}