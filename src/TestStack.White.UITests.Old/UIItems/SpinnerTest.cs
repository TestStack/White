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
            spinner = Window.Get<Spinner>("numericUpDown1");
        }

        [SetUp]
        public void SetUp()
        {
            spinner.Value = 4.0;
        }

        [Fact]
        public void Increment()
        {
            spinner.Increment();
            Assert.Equal(4.2, spinner.Value);
        }

        [Fact]
        public void Value()
        {
            Assert.Equal(4, spinner.Value);
        }

        [Fact]
        public void Decrement()
        {
            spinner.Decrement();
            Assert.Equal(3.8, spinner.Value);
        }
    }
}