using NUnit.Framework;
using TestStack.White.SystemExtensions;

namespace TestStack.White.UnitTests.SystemExtensions
{
    [TestFixture]
    public class DoubleXTest
    {
        [Test]
        public void IsInvalid()
        {
            Assert.That(double.NegativeInfinity.IsInvalid(), Is.True);
            Assert.That(double.PositiveInfinity.IsInvalid(), Is.True);
            Assert.That(double.NaN.IsInvalid(), Is.True);
            Assert.That(0d.IsInvalid(), Is.False);
        }
    }
}