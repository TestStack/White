using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Bricks.RuntimeFramework;
using White.Core.UIItems.TableItems;
using log4net;

namespace Repository.EntityMapping
{
    /// <summary>
    /// Represents an entity which can be mapped to the screen objects.
    /// </summary>
    [Serializable]
    public class Entity
    {
        [ScreenIgnore, XmlIgnore] private NestedEntities nestedEntities;
        private readonly ILog logger = LogManager.GetLogger(typeof(Entity));

        protected Entity() {}

        public Entity(TableRow tableRow, IList<string> header) : this()
        {
            int index = 0;
            foreach (TableCell cell in tableRow.Cells)
                AddData(header, index++, GetColumnValue(cell));
        }

        public virtual EntityField Field(string fieldName)
        {
            foreach (Entity entity in NestedEntities)
            {
                Class @class = new Class(entity.GetType());
                FieldInfo field = @class.GetField(fieldName);
                if (null != field) return new EntityField(entity, field);
            }
            return null;
        }

        private NestedEntities NestedEntities
        {
            get
            {
                if (nestedEntities == null) nestedEntities = new NestedEntities(this);
                return nestedEntities;
            }
        }

        public override string ToString()
        {
            return BuildStringRepresentation(new EntityTranslator(this).ToString);
        }

        public virtual string Header
        {
            get { return BuildStringRepresentation(new EntityTranslator(this).ToHeader); }
        }

        private void AddData(IList<string> header, int index, string value)
        {
            string fieldName = HeaderFormatter.To_Field_Name(header[index]);
            EntityField entityField = Field(fieldName);
            if (entityField == null) logger.DebugFormat("Could not find field: {0} in {1}", fieldName, GetType());
            else
            {
                entityField.SetValue(value);
            }
        }

        private class EntityTranslator
        {
            private readonly Entity entity;

            public EntityTranslator(Entity entity)
            {
                this.entity = entity;
            }

            public virtual string ToString(FieldInfo fieldInfo)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(fieldInfo.Name).Append("=");
                if (IsAnEntity(fieldInfo))
                {
                    builder.Append(fieldInfo.GetValue(entity).ToString());
                }
                else
                {
                    builder.Append(fieldInfo.GetValue(entity)).Append(", ");
                }
                return builder.ToString();
            }

            public virtual string ToHeader(FieldInfo fieldInfo)
            {
                return IsAnEntity(fieldInfo) ? ((Entity) fieldInfo.GetValue(entity)).Header : HeaderFormatter.To_Header_Column(fieldInfo.Name) + ", ";
            }

            private static bool IsAnEntity(FieldInfo fieldInfo)
            {
                return typeof (Entity).IsAssignableFrom(fieldInfo.FieldType);
            }
        }

        private delegate string Translate(FieldInfo fieldInfo);

        private string BuildStringRepresentation(Translate translate)
        {
            StringBuilder builder = new StringBuilder();
            Class @class = new Class(GetType());
            @class.EachField(delegate(FieldInfo fieldInfo)
                                 {
                                     if (fieldInfo.GetCustomAttributes(typeof (ScreenIgnoreAttribute), false).Length != 1)
                                         builder.Append(translate(fieldInfo));
                                 });

            return builder.ToString();
        }

        public class HeaderFormatter
        {
            // This replaces /es with '_or_' and spaces with '_'. a.k.a 'One Two'  will be converted to 'one_two' and 'One/Two' to one_or_to
            public static string To_Field_Name(string headerColumn)
            {
                string result = Regex.Replace(headerColumn.ToLower(), @"\s*(/)+\s*", "_or_");
                return Regex.Replace(result, @"[\s*]", "_");
            }

            public static string To_Header_Column(string fieldName)
            {
                string result = Regex.Replace(fieldName, @"_or_", "/");
                return Regex.Replace(result.ToUpper(), @"_", " ");
            }
        }

        private static string GetColumnValue(TableCell cell)
        {
            string value = cell.Value.ToString();
            return "(null)".Equals(value) ? null : value;
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ScreenIgnoreAttribute : Attribute {}
}