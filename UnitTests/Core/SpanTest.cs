using System.Windows;
using NUnit.Framework;

namespace White.Core
{
    [TestFixture, NormalCategory]
    public class SpanTest
    {
        [Test]
        public void Union()
        {
            VerticalSpan verticalSpan = new VerticalSpan(new Rect(10, 10, 0, 10)).Union(new Rect(10, 5, 0, 10));
            Assert.AreEqual(false, verticalSpan.DoesntContain(new Rect(10, 10, 0, 5)));
            Assert.AreEqual(false, verticalSpan.DoesntContain(new Rect(10, 10, 0, 10)));
        }

        [Test]
        public void Cut()
        {
            VerticalSpan verticalSpan = new VerticalSpan(new Rect(10, 10, 10, 10)).Minus(new Rect(10, 15, 5, 5));
            Assert.AreEqual(true, verticalSpan.DoesntContain(new Rect(10, 10, 10, 12)));
            Assert.AreEqual(false, verticalSpan.DoesntContain(new Rect(10, 10, 10, 4)));
        }

        [Test]
        public void EmptyIsOutside()
        {
            var verticalSpan = new VerticalSpan(new Rect(10, 10, 10, 10));
            Assert.AreEqual(true, verticalSpan.DoesntContain(Rect.Empty));
        }
    }
}