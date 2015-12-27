using System.Windows;
using NUnit.Framework;
using TestStack.White.UIItems.ListBoxItems;

namespace TestStack.White.UnitTests.UIItems
{
    [TestFixture]
    public class WpfComboBoxVerticalSpanCalculatorTest
    {
        [Test]
        public void Calculate()
        {
            var calculator = new WPFComboBoxVerticalSpanCalculator(Rectangle(0), Rectangle(10), Rectangle(100), 60);
            var verticalSpan = calculator.VerticalSpan;
            Assert.That(verticalSpan.Start, Is.EqualTo(10));
            Assert.That(verticalSpan.End, Is.EqualTo(70));
        }

        [Test]
        public void CalculateWhenListItemsDropUp()
        {
            var calculator = new WPFComboBoxVerticalSpanCalculator(Rectangle(70), Rectangle(10), Rectangle(100), 60);
            var verticalSpan = calculator.VerticalSpan;
            Assert.That(verticalSpan.Start, Is.EqualTo(10));
            Assert.That(verticalSpan.End, Is.EqualTo(70));
        }

        private Rect Rectangle(int y)
        {
            return new Rect(10, y, 10, 10);
        }
    }
}