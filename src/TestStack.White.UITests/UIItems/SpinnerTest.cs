using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory]
    public class SpinnerTest : ControlsActionTest
    {
        private Spinner spinner;

        protected override void TestFixtureSetUp()
        {
            spinner = window.Get<Spinner>("numericUpDown1");
        }

        [SetUp]
        public void SetUp()
        {
            spinner.Value = 4.0;
        }

        [Test]
        public void Increment()
        {
            spinner.Increment();
            Assert.AreEqual(4.2, spinner.Value);
        }

        [Test]
        public void Value()
        {
            Assert.AreEqual(4, spinner.Value);
        }

        [Test]
        public void Decrement()
        {
            spinner.Decrement();
            Assert.AreEqual(3.8, spinner.Value);
        }
    }
}