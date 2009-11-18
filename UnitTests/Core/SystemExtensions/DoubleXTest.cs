using NUnit.Framework;

namespace White.Core.SystemExtensions
{
    [TestFixture, NormalCategory]
    public class DoubleXTest
    {
        [Test]
        public void IsInvalid()
        {
            Assert.AreEqual(true, double.NegativeInfinity.IsInvalid());
            Assert.AreEqual(true, double.PositiveInfinity.IsInvalid());
            Assert.AreEqual(true, double.NaN.IsInvalid());
            Assert.AreEqual(false, 0d.IsInvalid());
        }
    }
}