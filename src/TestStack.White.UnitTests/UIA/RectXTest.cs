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
        public void ImmediateExteriorEast()
        {
            Assert.That(new Rect(10, 10, 10, 10).ImmediateExteriorEast(), Is.EqualTo(new Point(21, 15)));
        }

        [Test]
        public void ImmediateInteriorEast()
        {
            Assert.That(new Rect(10, 10, 10, 10).ImmediateInteriorEast(), Is.EqualTo(new Point(19, 15)));
        }

        [Test]
        public void ImmediateExteriorWest()
        {
            Assert.That(new Rect(10, 10, 10, 10).ImmediateExteriorWest(), Is.EqualTo(new Point(9, 15)));
        }

        [Test]
        public void ImmediateInteriorNorth()
        {
            Assert.That(new Point(15, 11), Is.EqualTo(new Rect(10, 10, 10, 10).ImmediateInteriorNorth()));
        }

        [Test]
        public void ImmediateInteriorSouth()
        {
            Assert.That(new Point(15, 19), Is.EqualTo(new Rect(10, 10, 10, 10).ImmediateInteriorSouth()));
        }
    }
}