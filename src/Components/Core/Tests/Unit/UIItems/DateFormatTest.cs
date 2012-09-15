using NUnit.Framework;
using White.Core.UIItems;

namespace White.Core.UnitTests.UIItems
{
    [TestFixture]
    public class DateFormatTest
    {
        [Test]
        public void DifferentDateFormats()
        {
            Assert.AreEqual(DateFormat.DayMonthYear, DateFormat.Create("-", "dd-MM-yyyy"));
            Assert.AreEqual(DateFormat.DayMonthYear, DateFormat.Create("-", "d-M-yyyy"));
        }
    }
}