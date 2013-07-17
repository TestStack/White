using System.Collections.Generic;
using TestStack.White.Repository.EntityMapping;
using TestStack.White.UIItems.TableItems;

namespace TestStack.White.UnitTests.Repository.EntityMapping
{
    internal class TestEntity : Entity
    {
        private string zo;
        private readonly NestedEntity nestedEntity = new NestedEntity();

        public string Zo
        {
            get { return zo; }
            set { zo = value; }
        }

        public TestEntity(TableRow tableRow, IList<string> header) : base(tableRow, header)
        {
        }

        public TestEntity(NestedEntity nestedEntity)
        {
            this.nestedEntity = nestedEntity;
        }

        public NestedEntity NestedEntity
        {
            get { return nestedEntity; }
        }
    }
}