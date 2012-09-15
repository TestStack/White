using System;
using System.Reflection;

namespace White.CustomControls.Peers.Automation
{
    public static class ObjectCopier
    {
        private const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

        public static object Copy(object @object, ICommandAssembly commandAssembly)
        {
            if (@object == null) return null;
            if (IsPrimitiveOrArrayOfPrimitives(@object.GetType())) return @object;

            Type copiedType = commandAssembly.GetType(@object.GetType());
            if (copiedType == null) return null;

            if (copiedType.IsArray)
            {
                Array copiedArray = Array.CreateInstance(copiedType.GetElementType(), ((Array) @object).Length);
                var array = ((Array) @object);
                for (int i = 0; i < array.Length; i++)
                    copiedArray.SetValue(Copy(array.GetValue(i), commandAssembly), i);
                return copiedArray;
            }
            return CopyNonArray(@object, copiedType);
        }

        private static object CopyNonArray(object @object, Type copiedType)
        {
            if (IsPrimitiveOrArrayOfPrimitives(copiedType)) return @object;

            object copy = Activator.CreateInstance(copiedType);
            FieldInfo[] copiedFields = copiedType.GetFields(bindingFlags);

            Type type = @object.GetType();
            FieldInfo[] fields = type.GetFields(bindingFlags);

            for (int i = 0; i < copiedFields.Length; i++)
            {
                copiedFields[i].SetValue(copy, fields[i].GetValue(@object));
            }
            return copy;
        }

        private static bool IsPrimitiveOrArrayOfPrimitives(Type copiedType)
        {
            return IsPrimitive(copiedType) || (copiedType.IsArray && IsPrimitiveOrArrayOfPrimitives(copiedType.GetElementType()));
        }

        private static bool IsPrimitive(Type copiedType)
        {
            return copiedType == null || copiedType.IsPrimitive || Equals(copiedType, typeof (string));
        }
    }
}