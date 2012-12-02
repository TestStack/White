using NUnit.Framework;
using Repository.EntityMapping;

namespace White.Repository.UnitTests.EntityMapping
{
    [TestFixture]
    public class EntityTest
    {
        [Test]
        public void SetFieldValue()
        {
            var testEntity = new TestEntity(new NestedEntity());
            testEntity.Field("yo").SetValue("5");
            Assert.AreEqual("5", testEntity.NestedEntity.Yo);

            Assert.AreEqual(null, testEntity.Field("bo"));
        }

        [Test]
        public void Should_Format_To_Field()
        {
            Assert.AreEqual("one_two", Entity.HeaderFormatter.To_Field_Name("One Two"));
            Assert.AreEqual("two_or_one", Entity.HeaderFormatter.To_Field_Name("Two /One"));
            Assert.AreEqual("two_or_one_three", Entity.HeaderFormatter.To_Field_Name("Two / One Three"));
        }

        [Test]
        public void Should_Format_To_Header_Column()
        {
            Assert.AreEqual("ONE TWO", Entity.HeaderFormatter.To_Header_Column("one_two"));
            Assert.AreEqual("TWO/ONE", Entity.HeaderFormatter.To_Header_Column("two_or_one"));
            Assert.AreEqual("TWO/ONE THREE", Entity.HeaderFormatter.To_Header_Column("two_or_one_three"));
        }

        [Test]
        public void To_String()
        {
            var nestedEntity = new NestedEntity {Yo = "7"};
            var testEntity = new TestEntity(nestedEntity) {Zo = "8"};
            Assert.AreEqual("zo=8, nestedEntity=yo=7, ", testEntity.ToString());
        }

        [Test]
        public void Header()
        {
            var nestedEntity = new NestedEntity();
            var testEntity = new TestEntity(nestedEntity);
            Assert.AreEqual("ZO, YO, ", testEntity.Header);
        }
    }

    internal class NestedEntity : Entity
    {
        private string yo;

        public virtual string Yo
        {
            get { return yo; }
            set { yo = value; }
        }
    }
}