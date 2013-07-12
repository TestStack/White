using White.Repository.EntityMapping;
using Xunit;

namespace White.Repository.UnitTests.EntityMapping
{
    public class EntityTest
    {
        [Fact]
        public void SetFieldValue()
        {
            var testEntity = new TestEntity(new NestedEntity());
            testEntity.Field("yo").SetValue("5");
            Assert.Equal("5", testEntity.NestedEntity.Yo);

            Assert.Equal(null, testEntity.Field("bo"));
        }

        [Fact]
        public void Should_Format_To_Field()
        {
            Assert.Equal("one_two", Entity.HeaderFormatter.To_Field_Name("One Two"));
            Assert.Equal("two_or_one", Entity.HeaderFormatter.To_Field_Name("Two /One"));
            Assert.Equal("two_or_one_three", Entity.HeaderFormatter.To_Field_Name("Two / One Three"));
        }

        [Fact]
        public void Should_Format_To_Header_Column()
        {
            Assert.Equal("ONE TWO", Entity.HeaderFormatter.To_Header_Column("one_two"));
            Assert.Equal("TWO/ONE", Entity.HeaderFormatter.To_Header_Column("two_or_one"));
            Assert.Equal("TWO/ONE THREE", Entity.HeaderFormatter.To_Header_Column("two_or_one_three"));
        }

        [Fact]
        public void To_String()
        {
            var nestedEntity = new NestedEntity {Yo = "7"};
            var testEntity = new TestEntity(nestedEntity) {Zo = "8"};
            Assert.Equal("zo=8, nestedEntity=yo=7, ", testEntity.ToString());
        }

        [Fact]
        public void Header()
        {
            var nestedEntity = new NestedEntity();
            var testEntity = new TestEntity(nestedEntity);
            Assert.Equal("ZO, YO, ", testEntity.Header);
        }
    }
}