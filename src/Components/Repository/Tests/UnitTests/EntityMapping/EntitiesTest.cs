using System.Collections.Generic;
using System.Text;
using White.Core.UIItems.TableItems;
using NUnit.Framework;
using White.Repository.EntityMapping;

namespace White.Repository.UnitTests.EntityMapping
{
    [TestFixture]
    public class EntitiesTest
    {
        [Test, Ignore]
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
            Assert.AreEqual(builder.ToString(), list.ToString());
        }

        [Test, Ignore]
        public void Construction()
        {
            var data = new List<string[]> {new[] {"1", "2"}, new[] {"3", "4"}};
            var entities = new Entities<TestEntity>(new[] {"ZO", "YO"}, data);
            Assert.AreEqual("1", entities[0].Zo);
            Assert.AreEqual("2", entities[0].NestedEntity.Yo);
            Assert.AreEqual("3", entities[1].Zo);
            Assert.AreEqual("4", entities[1].NestedEntity.Yo);
        }
    }

    public class Cricketer : Entity
    {
        private string name;
        private string country;
        private bool alive;

        public Cricketer(TableRow tableRow, IList<string> header) : base(tableRow, header){}

        public string Name
        {
            get { return name; }
        }
        public string Country
        {
            get { return country; }
        }
        public bool Alive
        {
            get { return alive; }
        }
    }

    public class GoogleWebsite
    {
        private string key;
        private string value;
    }
}