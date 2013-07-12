using System.Windows;
using TestStack.White.UIA;
using Xunit;

namespace TestStack.White.UnitTests.UIA
{
    public class RectXTest
    {
        [Fact]
        public void IsZero()
        {
            Assert.Equal(true, new Rect(0, 0, 0, 0).IsZeroSize());
            Assert.Equal(false, new Rect(0, 0, 1, 0).IsZeroSize());
        }

        [Fact]
        public void Center()
        {
            Assert.Equal(new Point(15, 15), new Rect(10, 10, 10, 10).Center());
            Assert.Equal(new Point(15, 5), new Rect(10, 0, 10, 10).Center());
        }

        [Fact]
        public void ImmediateExteriorEast()
        {
            Assert.Equal(new Point(21, 15), new Rect(10, 10, 10, 10).ImmediateExteriorEast());
        }

        [Fact]
        public void ImmediateInteriorEast()
        {
            Assert.Equal(new Point(19, 15), new Rect(10, 10, 10, 10).ImmediateInteriorEast());
        }

        [Fact]
        public void ImmediateExteriorWest()
        {
            Assert.Equal(new Point(9, 15), new Rect(10, 10, 10, 10).ImmediateExteriorWest());
        }

        [Fact]
        public void ImmediateInteriorNorth()
        {
            Assert.Equal(new Rect(10, 10, 10, 10).ImmediateInteriorNorth(), new Point(15, 11));
        }

        [Fact]
        public void ImmediateInteriorSouth()
        {
            Assert.Equal(new Rect(10, 10, 10, 10).ImmediateInteriorSouth(), new Point(15, 19));
        }
    }
}