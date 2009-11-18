using System.Globalization;
using NUnit.Framework;

namespace White.Core.UIItems
{
    [TestFixture, NormalCategory]
    public class DateFormatTest
    {
        [Test]
        public void DefaultDateFormat()
        {
            if ("en-GB".Equals(CultureInfo.CurrentCulture.Name))
                Assert.AreEqual(DateFormat.DayMonthYear, DateFormat.CultureDefault);
            else
                Assert.AreEqual(DateFormat.MonthDayYear, DateFormat.CultureDefault);
        }

        [Test]
        public void DifferentDateFormats()
        {
            Assert.AreEqual(DateFormat.DayMonthYear, DateFormat.Create("-", "dd-MM-yyyy"));
            Assert.AreEqual(DateFormat.DayMonthYear, DateFormat.Create("-", "d-M-yyyy"));
        }
    }
}