using System;
using System.Collections.Generic;
using NUnit.Framework;
using TestStack.White.UITests.Infrastructure;
using White.Core.UIItems;

namespace TestStack.White.UITests.ControlTests.InputControls
{
    public class DatePickerTests : WhiteTestBase
    {
        protected override void RunTest(FrameworkId framework)
        {
            RunTest(() => GetDate(DateTime.Today), FrameworkId.Winforms);
            RunTest(() => GetDate(null), FrameworkId.Wpf);
            RunTest(SetDate); 
        }

        private void GetDate(DateTime? defaultTime)
        {
            var dateTimePicker = MainWindow.Get<DateTimePicker>("DatePicker");
            Assert.AreEqual(defaultTime, dateTimePicker.Date);
        }

        private void SetDate()
        {
            var dateTimePicker = MainWindow.Get<DateTimePicker>("DatePicker");
            DateTime changedDate = DateTime.Today.AddDays(23);
            dateTimePicker.Date = changedDate;
            Assert.AreEqual(changedDate, dateTimePicker.Date);

            changedDate = DateTime.Today.AddDays(23);
            dateTimePicker.Date = changedDate;
            Assert.AreEqual(changedDate, dateTimePicker.Date);
        }

        protected override IEnumerable<FrameworkId> SupportedFrameworks()
        {
            yield return FrameworkId.Wpf;
            yield return FrameworkId.Winforms;
        }
    }
}