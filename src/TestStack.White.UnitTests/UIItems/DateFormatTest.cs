using White.Core.UIItems;
using Xunit;

namespace TestStack.White.Core.UnitTests.UIItems
{
    public class DateFormatTest
    {
        [Fact]
        public void DifferentDateFormats()
        {
            Assert.Equal(DateFormat.dayMonthYear, DateFormat.Create("-", "dd-MM-yyyy"));
            Assert.Equal(DateFormat.dayMonthYear, DateFormat.Create("-", "d-M-yyyy"));
        }
    }
}