using System;
using NUnit.Framework;
using White.Core;
using White.Core.Testing;
using White.Core.UIItems;
using White.UnitTests.Core.Testing;

namespace White.UnitTests.Core.UIItems
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
            dateTimePicker.Date = changedDate;
            Assert.AreEqual(changedDate, dateTimePicker.Date);
        }
    }
}