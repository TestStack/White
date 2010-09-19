using NUnit.Framework;
using White.Core.UIItems.Finders;

namespace White.Core.UnitTests.UIItems.Finders
{
    [TestFixture]
    public class IndexConditionTest
    {
        [Test]
        public void TestEquals()
        {
            Assert.AreEqual(new IndexCondition(1), new IndexCondition(1));
            Assert.AreNotEqual(new IndexCondition(1), new IndexCondition(2));
            Assert.AreEqual(new IndexCondition(-1), new IndexCondition(-1));
        }
    }
}