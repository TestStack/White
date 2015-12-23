using NUnit.Framework;
using TestStack.White.UIItems;

namespace TestStack.White.UnitTests.UIItems
{
    [TestFixture]
    public class DateFormatTest
    {
        [Test]
        public void DifferentDateFormats()
        {
            Assert.That(DateFormat.Create("-", "dd-MM-yyyy"), Is.EqualTo(DateFormat.DayMonthYear));
            Assert.That(DateFormat.Create("-", "d-M-yyyy"), Is.EqualTo(DateFormat.DayMonthYear));
        }
    }
}