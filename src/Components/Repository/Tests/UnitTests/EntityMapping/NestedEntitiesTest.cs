using NUnit.Framework;
using Repository.EntityMapping;

namespace White.Repository.UnitTests.EntityMapping
{
    [TestFixture]
    public class NestedEntitiesTest
    {
        [Test]
        public void Create()
        {
            TestEntity testEntity = new TestEntity(new NestedEntity());
            Assert.AreEqual(2, new NestedEntities(testEntity).Count);
        }
    }
}