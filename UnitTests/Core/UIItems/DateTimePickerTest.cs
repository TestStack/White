using System;
using NUnit.Framework;
using White.Core.Testing;

namespace White.Core.UIItems
{
    [TestFixture, WinFormCategory]
    public class DateTimePickerTest : ControlsActionTest
    {
        [Test]
        public void GetDate()
        {
            DateTimePicker dateTimePicker = window.Get<DateTimePicker>("dateTimePicker");
            Assert.AreEqual(DateTime.Today, dateTimePicker.Date);
        }

        [Test]
        public void SetDate()
        {
            DateTimePicker dateTimePicker = window.Get<DateTimePicker>("dateTimePicker");
            DateTime changedDate = DateTime.Today.AddDays(23);
            dateTimePicker.Date = changedDate;
            Assert.AreEqual(changedDate, dateTimePicker.Date);
        }
    }
}