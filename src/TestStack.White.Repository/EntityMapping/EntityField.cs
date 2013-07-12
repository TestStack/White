using System;
using System.Reflection;
using White.Core.UIItems;

namespace TestStack.White.Repository.EntityMapping
{
    public class EntityField
    {
        private readonly Entity entity;
        private readonly FieldInfo fieldInfo;

        public EntityField(Entity entity, FieldInfo fieldInfo)
        {
            this.entity = entity;
            this.fieldInfo = fieldInfo;
        }

        public virtual bool SetValue(string value)
        {
            try
            {
                if (fieldInfo.FieldType.Equals(typeof (bool)))
                    fieldInfo.SetValue(entity, bool.Parse(value));
                else if (fieldInfo.FieldType.Equals(typeof (int)))
                    fieldInfo.SetValue(entity, int.Parse(value));
                else if (fieldInfo.FieldType.Equals(typeof (short)))
                    fieldInfo.SetValue(entity, short.Parse(value));
                else if (fieldInfo.FieldType.Equals(typeof (decimal)))
                    fieldInfo.SetValue(entity, decimal.Parse(value));
                else if (fieldInfo.FieldType.Equals(typeof (double)))
                    fieldInfo.SetValue(entity, double.Parse(value));
                else if (fieldInfo.FieldType.Equals(typeof (long)))
                    fieldInfo.SetValue(entity, long.Parse(value));
                else if (fieldInfo.FieldType.Equals(typeof (float)))
                    fieldInfo.SetValue(entity, float.Parse(value));
                else if (fieldInfo.FieldType.Equals(typeof (string)))
                    fieldInfo.SetValue(entity, value);
                else if (fieldInfo.FieldType.Equals(typeof (char)))
                    fieldInfo.SetValue(entity, char.Parse(value));
                else if (fieldInfo.FieldType.Equals(typeof (byte)))
                    fieldInfo.SetValue(entity, byte.Parse(value));

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public virtual void SetValueOn(UIItem uiItem)
        {
            object value = fieldInfo.GetValue(entity);
            if (null != value) uiItem.SetValue(value);
        }
    }
}