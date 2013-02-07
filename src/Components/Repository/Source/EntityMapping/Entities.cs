using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using White.Core.UIItems.TableItems;

namespace Repository.EntityMapping
{
    [Serializable]
    public class Entities<T> : List<T> where T : Entity
    {
        public Entities(){}
                                                                                                                                                                                                                                                                
        public Entities(Table table)
        {
            var header = GetHeader(table);
            foreach (var row in table.Rows)
                Add((T) Activator.CreateInstance(typeof (T), row, header));
        }

        public Entities(string [] header, IEnumerable<string[]> data)
        {
            foreach (string[] d in data)
                Add((T)Activator.CreateInstance(typeof(T), d, header));
        }

        private static IList<string> GetHeader(Table table)
        {
            return table.Header.Columns.Select(column => column.Name).ToList();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            if (Count > 0)
            {
                builder.AppendLine(this[0].Header);
                foreach (T entity in this)
                    builder.AppendLine(entity.ToString());
            }
            return builder.ToString();
        }
    }
}