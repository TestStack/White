using System;
using System.Collections.Generic;
using NUnit.Framework;
using White.Core.UIItems;

namespace TestStack.White.UITests.ControlTests.InputControls
{
    public class DatePickerTests : WhiteTestBase
    {
        protected override void RunTest(WindowsFramework framework)
        {
            RunTest(() => GetDate(DateTime.Today), WindowsFramework.WinForms);
            RunTest(() => GetDate(null), WindowsFramework.Wpf, WindowsFramework.Silverlight);
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

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
            yield return WindowsFramework.Silverlight;
        }
    }
}