using System;
using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory]
    public class DateTimePickerTest : ControlsActionTest
    {
        [Test]
        public void GetDate()
        {
            var dateTimePicker = window.Get<DateTimePicker>("dateTimePicker");
            Assert.AreEqual(DateTime.Today, dateTimePicker.Date);
        }

        [Test]
        public void SetDate()
        {
            var dateTimePicker = window.Get<DateTimePicker>("dateTimePicker");
            DateTime changedDate = DateTime.Today.AddDays(23);
            dateTimePicker.SetDate(changedDate, DateFormat.CultureDefault);
            Assert.AreEqual(changedDate, dateTimePicker.Date);
            
            changedDate = DateTime.Today.AddDays(23);
            dateTimePicker.SetDate(changedDate, DateFormat.CultureDefault);
            Assert.AreEqual(changedDate, dateTimePicker.Date);
        }
    }
}