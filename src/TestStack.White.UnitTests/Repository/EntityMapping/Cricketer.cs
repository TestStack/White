using System.Collections.Generic;
using TestStack.White.ScreenObjects.EntityMapping;
using TestStack.White.UIItems.TableItems;

namespace TestStack.White.UnitTests.Repository.EntityMapping
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