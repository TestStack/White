using System;
using System.Collections.Generic;
using System.Text;
using Bricks.RuntimeFramework;
using White.Core.UIItems.TableItems;

namespace Repository.EntityMapping
{
    [Serializable]
    public class Entities<T> : List<T> where T : Entity
    {
        public Entities(){}
                                                                                                                                                                                                                                                                
        public Entities(Table table)
        {
            IList<string> header = GetHeader(table);
            foreach (TableRow row in table.Rows)
                Add((T) new Class(typeof (T)).New(row, header));
        }

        public Entities(string [] header, IEnumerable<string[]> data)
        {
            foreach (string[] d in data)
                Add((T)new Class(typeof(T)).New(d, header));
        }

        private static IList<string> GetHeader(Table table)
        {
            var header = new List<string>();
            foreach (TableColumn column in table.Header.Columns)
                header.Add(column.Name);
            return header;
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