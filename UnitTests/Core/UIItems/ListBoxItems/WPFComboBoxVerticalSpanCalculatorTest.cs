using System.Windows;
using NUnit.Framework;

namespace White.Core.UIItems.ListBoxItems
{
    [TestFixture, WPFCategory]
    public class WPFComboBoxVerticalSpanCalculatorTest
    {
        [Test]
        public void Calculate()
        {
            var calculator = new WPFComboBoxVerticalSpanCalculator(Rectangle(0), Rectangle(10), Rectangle(100), 60);
            VerticalSpan verticalSpan = calculator.VerticalSpan;
            Assert.AreEqual(10, verticalSpan.Start);
            Assert.AreEqual(70, verticalSpan.End);
        }

        [Test]
        public void CalculateWhenListItemsDropUp()
        {
            var calculator = new WPFComboBoxVerticalSpanCalculator(Rectangle(70), Rectangle(10), Rectangle(100), 60);
            VerticalSpan verticalSpan = calculator.VerticalSpan;
            Assert.AreEqual(10, verticalSpan.Start);
            Assert.AreEqual(70, verticalSpan.End);
        }

        private static Rect Rectangle(int y)
        {
            return new Rect(10, y, 10, 10);
        }
    }
}