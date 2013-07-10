using System.Collections.Generic;
using White.Core.UIItems.TableItems;
using White.Repository.EntityMapping;

namespace White.Repository.UnitTests.EntityMapping
{
    public class Cricketer : Entity
    {
        protected string name;
        protected string country;
        protected bool alive;

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
}