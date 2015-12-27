using NUnit.Framework;
using System.Windows;

namespace TestStack.White.UnitTests
{
    [TestFixture]
    public class SpanTests
    {
        [Test]
        public void UnionTest()
        {
            var verticalSpan = new VerticalSpan(new Rect(10, 10, 0, 10)).Union(new Rect(10, 5, 0, 10));
            Assert.That(verticalSpan.DoesntContain(new Rect(10, 10, 0, 5)), Is.False);
            Assert.That(verticalSpan.DoesntContain(new Rect(10, 10, 0, 10)), Is.False);
        }

        [Test]
        public void CutTest()
        {
            var verticalSpan = new VerticalSpan(new Rect(10, 10, 10, 10)).Minus(new Rect(10, 15, 5, 5));
            Assert.That(verticalSpan.DoesntContain(new Rect(10, 10, 10, 12)), Is.True);
            Assert.That(verticalSpan.DoesntContain(new Rect(10, 10, 10, 4)), Is.False);
        }

        [Test]
        public void EmptyIsOutsideTest()
        {
            var verticalSpan = new VerticalSpan(new Rect(10, 10, 10, 10));
            Assert.That(verticalSpan.DoesntContain(Rect.Empty), Is.True);
        }
    }
}