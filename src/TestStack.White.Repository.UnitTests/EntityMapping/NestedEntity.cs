using White.Repository.EntityMapping;

namespace White.Repository.UnitTests.EntityMapping
{
    internal class NestedEntity : Entity
    {
        private string yo;

        // ReSharper disable once ConvertToAutoProperty
        public virtual string Yo
        {
            get { return yo; }
            set { yo = value; }
        }
    }
}