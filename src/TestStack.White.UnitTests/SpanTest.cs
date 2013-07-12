using System.Windows;
using White.Core;
using Xunit;

namespace TestStack.White.Core.UnitTests
{
    public class SpanTest
    {
        [Fact]
        public void Union()
        {
            VerticalSpan verticalSpan = new VerticalSpan(new Rect(10, 10, 0, 10)).Union(new Rect(10, 5, 0, 10));
            Assert.Equal(false, verticalSpan.DoesntContain(new Rect(10, 10, 0, 5)));
            Assert.Equal(false, verticalSpan.DoesntContain(new Rect(10, 10, 0, 10)));
        }

        [Fact]
        public void Cut()
        {
            VerticalSpan verticalSpan = new VerticalSpan(new Rect(10, 10, 10, 10)).Minus(new Rect(10, 15, 5, 5));
            Assert.Equal(true, verticalSpan.DoesntContain(new Rect(10, 10, 10, 12)));
            Assert.Equal(false, verticalSpan.DoesntContain(new Rect(10, 10, 10, 4)));
        }

        [Fact]
        public void EmptyIsOutside()
        {
            var verticalSpan = new VerticalSpan(new Rect(10, 10, 10, 10));
            Assert.Equal(true, verticalSpan.DoesntContain(Rect.Empty));
        }
    }
}