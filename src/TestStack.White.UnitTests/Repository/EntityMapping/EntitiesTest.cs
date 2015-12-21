using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using TestStack.White.ScreenObjects.EntityMapping;

namespace TestStack.White.UnitTests.Repository.EntityMapping
{
    [TestFixture]
    public class EntitiesTest
    {
        [Test]
        [Ignore("No idea what this is doing")]
        public void To_String()
        {
            var list = new Entities<Entity>();
            var nestedEntity = new NestedEntity();
            var testEntity = new TestEntity(nestedEntity);
            nestedEntity.Yo = "7";
            testEntity.Zo = "8";
            list.Add(testEntity);
            var builder = new StringBuilder();
            builder.AppendLine("ZO, YO, ");
            builder.AppendLine("8, 7, ");
            Assert.That(list.ToString(), Is.EqualTo(builder.ToString()));
        }

        [Test]
        [Ignore("No idea what this is doing")]
        public void Construction()
        {
            var data = new List<string[]> { new[] { "1", "2" }, new[] { "3", "4" } };
            var entities = new Entities<TestEntity>(new[] { "ZO", "YO" }, data);
            Assert.That(entities[0].Zo, Is.EqualTo("1"));
            Assert.That(entities[0].NestedEntity.Yo, Is.EqualTo("2"));
            Assert.That(entities[1].Zo, Is.EqualTo("3"));
            Assert.That(entities[1].NestedEntity.Yo, Is.EqualTo("4"));
        }
    }
}