using System;
using System.Globalization;
using Bricks.RuntimeFramework;

namespace White.Core.UIItems
{
    /// <summary>
    /// Format in which the data in entered in the DateTimePicker. e.g. DayMonthYear, DayYearMonth, etc.
    /// </summary>
    public class DateFormat
    {
        public static DateFormat DayMonthYear = new DateFormat(DateUnit.Day, DateUnit.Month, DateUnit.Year);
        public static DateFormat DayYearMonth = new DateFormat(DateUnit.Day, DateUnit.Year, DateUnit.Month);
        public static DateFormat MonthDayYear = new DateFormat(DateUnit.Month, DateUnit.Day, DateUnit.Year);
        public static DateFormat MonthYearDay = new DateFormat(DateUnit.Month, DateUnit.Year, DateUnit.Day);
        public static DateFormat YearMonthDay = new DateFormat(DateUnit.Year, DateUnit.Month, DateUnit.Day);
        public static DateFormat YearDayMonth = new DateFormat(DateUnit.Year, DateUnit.Day, DateUnit.Month);

        private readonly BricksCollection<DateUnit> dateUnits = new BricksCollection<DateUnit>();

        protected DateFormat() {}

        private DateFormat(params DateUnit[] unitsInOrder)
        {
            dateUnits.AddRange(unitsInOrder);
        }

        public static DateFormat CultureDefault
        {
            get
            {
                DateTimeFormatInfo format = CultureInfo.CurrentCulture.DateTimeFormat;
                string pattern = format.ShortDatePattern;
                return Create(format.DateSeparator, pattern);
            }
        }

        public static DateFormat Create(string dateSeparator, string pattern)
        {
            string[] parts = pattern.Split(dateSeparator.ToCharArray());
            var dateFormat = new DateFormat();
            foreach (string part in parts)
            {
                if (part.ToLower().Contains("d")) dateFormat.dateUnits.Add(DateUnit.Day);
                else if (part.ToLower().Contains("m")) dateFormat.dateUnits.Add(DateUnit.Month);
                else if (part.ToLower().Contains("yy")) dateFormat.dateUnits.Add(DateUnit.Year);
            }
            return dateFormat;
        }

        public static DateFormat Parse(string @string)
        {
            string[] parts = @string.Split(',');
            var newDateFormat = new DateFormat();
            foreach (string part in parts)
            {
                var dateUnit = (DateUnit) Enum.Parse(typeof (DateUnit), part);
                newDateFormat.dateUnits.Add(dateUnit);
            }
            return newDateFormat;
        }

        public virtual int DisplayValue(DateTime dateTime, int index)
        {
            DateUnit dateUnit = dateUnits[index];
            switch (dateUnit)
            {
                case DateUnit.Day:
                    return dateTime.Day;
                case DateUnit.Month:
                    return dateTime.Month;
                case DateUnit.Year:
                    return dateTime.Year;
            }
            throw new WhiteAssertionException();
        }

        public override string ToString()
        {
            return dateUnits.ToString();
        }

        public override bool Equals(object other)
        {
            var otherFormat = other as DateFormat;
            if (otherFormat == null) return false;
            return dateUnits.ItemwiseEquals(otherFormat.dateUnits);
        }

        public override int GetHashCode()
        {
            return dateUnits[0].GetHashCode() + 3*dateUnits[1].GetHashCode() + 5*dateUnits[2].GetHashCode();
        }
    }
}