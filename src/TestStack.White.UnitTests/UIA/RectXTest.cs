using System.Windows;
using NUnit.Framework;
using TestStack.White.UIA;

namespace TestStack.White.UnitTests.UIA
{
    [TestFixture]
    public class RectXTest
    {
        [Test]
        public void IsZero()
        {
            Assert.That(new Rect(0, 0, 0, 0).IsZeroSize(), Is.True);
            Assert.That(new Rect(0, 0, 1, 0).IsZeroSize(), Is.False);
        }

        [Test]
        public void Center()
        {
            Assert.That(new Rect(10, 10, 10, 10).Center(), Is.EqualTo(new Point(15, 15)));
            Assert.That(new Rect(10, 0, 10, 10).Center(), Is.EqualTo(new Point(15, 5)));
        }

        [Test]
        public void North()
        {
            Assert.That(new Rect(10, 10, 10, 10).North(), Is.EqualTo(new Point(15, 10)));
        }

        [Test]
        public void East()
        {
            Assert.That(new Rect(10, 10, 10, 10).East(), Is.EqualTo(new Point(20, 15)));
        }

        [Test]
        public void South()
        {
            Assert.That(new Rect(10, 10, 10, 10).South(), Is.EqualTo(new Point(15, 20)));
        }

        [Test]
        public void West()
        {
            Assert.That(new Rect(10, 10, 10, 10).West(), Is.EqualTo(new Point(10, 15)));
        }

        [Test]
        public void ImmediateInteriorNorth()
        {
            Assert.That(new Rect(10, 10, 10, 10).ImmediateInteriorNorth(), Is.EqualTo(new Point(15, 11)));
        }

        [Test]
        public void ImmediateExteriorNorth()
        {
            Assert.That(new Rect(10, 10, 10, 10).ImmediateExteriorNorth(), Is.EqualTo(new Point(15, 9)));
        }

        [Test]
        public void ImmediateInteriorSouth()
        {
            Assert.That(new Rect(10, 10, 10, 10).ImmediateInteriorSouth(), Is.EqualTo(new Point(15, 19)));
        }

        [Test]
        public void ImmediateExteriorSouth()
        {
            Assert.That(new Rect(10, 10, 10, 10).ImmediateExteriorSouth(), Is.EqualTo(new Point(15, 21)));
        }

        [Test]
        public void ImmediateInteriorEast()
        {
            Assert.That(new Rect(10, 10, 10, 10).ImmediateInteriorEast(), Is.EqualTo(new Point(19, 15)));
        }

        [Test]
        public void ImmediateExteriorEast()
        {
            Assert.That(new Rect(10, 10, 10, 10).ImmediateExteriorEast(), Is.EqualTo(new Point(21, 15)));
        }

        [Test]
        public void ImmediateInteriorWest()
        {
            Assert.That(new Rect(10, 10, 10, 10).ImmediateInteriorWest(), Is.EqualTo(new Point(11, 15)));
        }

        [Test]
        public void ImmediateExteriorWest()
        {
            Assert.That(new Rect(10, 10, 10, 10).ImmediateExteriorWest(), Is.EqualTo(new Point(9, 15)));
        }
    }
}