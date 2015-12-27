using NUnit.Framework;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UnitTests.UIItems.Finders
{
    [TestFixture]
    public class IndexConditionTest
    {
        [Test]
        public void TestEquals()
        {
            Assert.That(new IndexCondition(1), Is.EqualTo(new IndexCondition(1)));
            Assert.That(new IndexCondition(1), Is.Not.EqualTo(new IndexCondition(2)));
            Assert.That(new IndexCondition(-1), Is.EqualTo(new IndexCondition(-1)));
        }
    }
}