using System;
using System.Collections.Generic;
using TestStack.White.UIItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.InputControls
{
    public class DatePickerTests : WhiteTestBase
    {
        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            SelectInputControls();
            RunTest(() => GetDate(DateTime.Today), WindowsFramework.WinForms);
            RunTest(() => GetDate(null), WindowsFramework.Wpf, WindowsFramework.Silverlight);
            RunTest(SetDate);
            RunTest(ClearDate, WindowsFramework.Wpf, WindowsFramework.WinForms);
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

        private void ClearDate()
        {
            var dateTimePicker = MainWindow.Get<DateTimePicker>("DatePicker");
            var date = dateTimePicker.Date;
            dateTimePicker.Date = null;

            //Checks that date in Win32 DateTimePicker didn't change, but date in WPF DateTimePicker was cleared
            Assert.Equal(dateTimePicker.Framework == WindowsFramework.Wpf ? DateTime.Parse("") : date,
                dateTimePicker.Date);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
            yield return WindowsFramework.Wpf;
        }
    }
}