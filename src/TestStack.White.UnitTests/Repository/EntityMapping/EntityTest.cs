using NUnit.Framework;
using TestStack.White.ScreenObjects.EntityMapping;

namespace TestStack.White.UnitTests.Repository.EntityMapping
{
    [TestFixture]
    public class EntityTest
    {
        [Test]
        public void SetFieldValue()
        {
            var testEntity = new TestEntity(new NestedEntity());
            testEntity.Field("yo").SetValue("5");
            Assert.That(testEntity.NestedEntity.Yo, Is.EqualTo("5"));
            Assert.That(testEntity.Field("bo"), Is.EqualTo(null));
        }

        [Test]
        public void Should_Format_To_Field()
        {
            Assert.That(Entity.HeaderFormatter.To_Field_Name("One Two"), Is.EqualTo("one_two"));
            Assert.That(Entity.HeaderFormatter.To_Field_Name("Two /One"), Is.EqualTo("two_or_one"));
            Assert.That(Entity.HeaderFormatter.To_Field_Name("Two / One Three"), Is.EqualTo("two_or_one_three"));
        }

        [Test]
        public void Should_Format_To_Header_Column()
        {
            Assert.That(Entity.HeaderFormatter.To_Header_Column("one_two"), Is.EqualTo("ONE TWO"));
            Assert.That(Entity.HeaderFormatter.To_Header_Column("two_or_one"), Is.EqualTo("TWO/ONE"));
            Assert.That(Entity.HeaderFormatter.To_Header_Column("two_or_one_three"), Is.EqualTo("TWO/ONE THREE"));
        }

        [Test]
        public void To_String()
        {
            var nestedEntity = new NestedEntity {Yo = "7"};
            var testEntity = new TestEntity(nestedEntity) {Zo = "8"};
            Assert.That(testEntity.ToString(), Is.EqualTo("zo=8, nestedEntity=yo=7, "));
        }

        [Test]
        public void Header()
        {
            var nestedEntity = new NestedEntity();
            var testEntity = new TestEntity(nestedEntity);
            Assert.That(testEntity.Header, Is.EqualTo("ZO, YO, "));
        }
    }
}