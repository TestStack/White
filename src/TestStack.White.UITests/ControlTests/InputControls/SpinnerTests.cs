using System.Collections.Generic;
using NUnit.Framework;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.ControlTests.InputControls
{
    [TestFixture(WindowsFramework.WinForms)]
    public class SpinnerTests : WhiteUITestBase
    {
        public SpinnerTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectInputControls();
        }

        [Test]
        [Category("NeedsFix")]
        [Ignore("NeedsFix")]
        public void IncrementTest()
        {
            var spinner = MainWindow.Get<Spinner>("NumericUpDown");
            spinner.Value = 4.0;
            spinner.Increment();
            Assert.That(spinner.Value, Is.EqualTo(4.2));
        }

        [Test]
        [Category("NeedsFix")]
        [Ignore("NeedsFix")]
        public void DecrementTest()
        {
            var spinner = MainWindow.Get<Spinner>("NumericUpDown");
            spinner.Value = 4.0;
            spinner.Decrement();
            Assert.That(spinner.Value, Is.EqualTo(3.8));
        }

        [Test]
        [Category("NeedsFix")]
        [Ignore("NeedsFix")]
        public void ValueTest()
        {
            var spinner = MainWindow.Get<Spinner>("NumericUpDown");
            spinner.Value = 4.0;
            Assert.That(spinner.Value, Is.EqualTo(4));
        }
    }
}