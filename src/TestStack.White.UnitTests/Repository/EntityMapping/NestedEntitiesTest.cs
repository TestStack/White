using NUnit.Framework;
using TestStack.White.ScreenObjects.EntityMapping;

namespace TestStack.White.UnitTests.Repository.EntityMapping
{
    [TestFixture]
    public class NestedEntitiesTest
    {
        [Test]
        public void Create()
        {
            var testEntity = new TestEntity(new NestedEntity());
            Assert.That(new NestedEntities(testEntity), Has.Count.EqualTo(2));
        }
    }
}