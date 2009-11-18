using NUnit.Framework;

namespace Repository.EntityMapping
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