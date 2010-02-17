using NUnit.Framework;

namespace White.Core.UIItems
{
    [TestFixture, NormalCategory]
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