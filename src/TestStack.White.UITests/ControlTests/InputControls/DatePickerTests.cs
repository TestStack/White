using System;
using System.Collections.Generic;
using White.Core.UIItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.InputControls
{
    public class DatePickerTests : WhiteTestBase
    {
        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(() => GetDate(DateTime.Today), WindowsFramework.WinForms);
            RunTest(() => GetDate(null), WindowsFramework.Wpf, WindowsFramework.Silverlight);
            RunTest(SetDate); 
        }

        private void GetDate(DateTime? defaultTime)
        {
            var dateTimePicker = MainWindow.Get<DateTimePicker>("DatePicker");
            Assert.Equal(defaultTime, dateTimePicker.Date);
        }

        private void SetDate()
        {
            var dateTimePicker = MainWindow.Get<DateTimePicker>("DatePicker");
            DateTime changedDate = DateTime.Today.AddDays(23);
            dateTimePicker.Date = changedDate;
            Assert.Equal(changedDate, dateTimePicker.Date);

            changedDate = DateTime.Today.AddDays(23);
            dateTimePicker.Date = changedDate;
            Assert.Equal(changedDate, dateTimePicker.Date);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
            yield return WindowsFramework.Silverlight;
        }
    }
}