using NUnit.Framework;
using White.Core.SystemExtensions;

namespace White.Core.UnitTests.SystemExtensions
{
    [TestFixture]
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