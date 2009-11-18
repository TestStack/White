using System.Windows;
using NUnit.Framework;

namespace White.Core.UIA
{
    [TestFixture, NormalCategory]
    public class RectXTest
    {
        [Test]
        public void IsZero()
        {
            Assert.AreEqual(true, new Rect(0, 0, 0, 0).IsZeroSize());
            Assert.AreEqual(false, new Rect(0, 0, 1, 0).IsZeroSize());
        }

        [Test]
        public void Center()
        {
            Assert.AreEqual(new Point(15, 15), new Rect(10, 10, 10, 10).Center());
            Assert.AreEqual(new Point(15, 5), new Rect(10, 0, 10, 10).Center());
        }

        [Test]
        public void ImmediateExteriorEast()
        {
            Assert.AreEqual(new Point(21, 15), new Rect(10, 10, 10, 10).ImmediateExteriorEast());
        }

        [Test]
        public void ImmediateInteriorEast()
        {
            Assert.AreEqual(new Point(19, 15), new Rect(10, 10, 10, 10).ImmediateInteriorEast());
        }

        [Test]
        public void ImmediateExteriorWest()
        {
            Assert.AreEqual(new Point(9, 15), new Rect(10, 10, 10, 10).ImmediateExteriorWest());
        }

        [Test]
        public void ImmediateInteriorNorth()
        {
            Assert.AreEqual(new Rect(10, 10, 10, 10).ImmediateInteriorNorth(), new Point(15, 11));
        }

        [Test]
        public void ImmediateInteriorSouth()
        {
            Assert.AreEqual(new Rect(10, 10, 10, 10).ImmediateInteriorSouth(), new Point(15, 19));
        }
    }
}