using System;
using System.Reflection;

namespace White.CustomControls.Automation
{
    public static class ObjectCopier
    {
        public static object Copy(object @object, Type copiedType)
        {
            if (copiedType.IsPrimitive || Equals(copiedType, typeof(string))) return @object;

            object copy = Activator.CreateInstance(copiedType);
            FieldInfo[] copiedFields = copiedType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            Type type = @object.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            for (int i = 0; i < copiedFields.Length; i++)
            {
                copiedFields[i].SetValue(copy, fields[i].GetValue(@object));                
            }
            return copy;
        }
    }
}