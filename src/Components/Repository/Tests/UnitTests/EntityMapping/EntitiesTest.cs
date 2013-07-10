using System.Collections.Generic;
using System.Text;
using White.Repository.EntityMapping;
using Xunit;

namespace White.Repository.UnitTests.EntityMapping
{
    public class EntitiesTest
    {
        [Fact(Skip = "No idea what this is doing")]
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
            Assert.Equal(builder.ToString(), list.ToString());
        }

        [Fact(Skip = "No idea what this is doing")]
        public void Construction()
        {
            var data = new List<string[]> {new[] {"1", "2"}, new[] {"3", "4"}};
            var entities = new Entities<TestEntity>(new[] {"ZO", "YO"}, data);
            Assert.Equal("1", entities[0].Zo);
            Assert.Equal("2", entities[0].NestedEntity.Yo);
            Assert.Equal("3", entities[1].Zo);
            Assert.Equal("4", entities[1].NestedEntity.Yo);
        }
    }
}