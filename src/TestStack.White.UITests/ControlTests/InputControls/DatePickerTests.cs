using NUnit.Framework;
using System;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.ControlTests.InputControls
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class DatePickerTests : WhiteUITestBase
    {
        public DatePickerTests(WindowsFramework framework)
            : base(framework) { }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectInputControls();
        }

        [Test]
        public void GetDateTest()
        {
            var defaultTime = Framework == WindowsFramework.WinForms ? (DateTime?)DateTime.Today : null;
            var dateTimePicker = MainWindow.Get<DateTimePicker>("DatePicker");
            Assert.That(dateTimePicker.Date, Is.EqualTo(defaultTime));
        }

        [Test]
        public void SetDateTest()
        {
            var dateTimePicker = MainWindow.Get<DateTimePicker>("DatePicker");
            var changedDate = DateTime.Today.AddDays(23);
            dateTimePicker.Date = changedDate;
            Assert.That(dateTimePicker.Date, Is.EqualTo(changedDate));

            changedDate = DateTime.Today.AddDays(23);
            dateTimePicker.Date = changedDate;
            Assert.That(dateTimePicker.Date, Is.EqualTo(changedDate));
        }

        [Test]
        public void ClearDateTest()
        {
            var dateTimePicker = MainWindow.Get<DateTimePicker>("DatePicker");
            var date = dateTimePicker.Date;
            dateTimePicker.Date = null;
            //Checks that date in Win32 DateTimePicker didn't change, but date in WPF DateTimePicker was cleared
            Assert.That(dateTimePicker.Date, Is.EqualTo(Framework == WindowsFramework.Wpf ? null : date));
        }
    }
}