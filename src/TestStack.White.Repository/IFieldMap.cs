using System;

namespace TestStack.White.Repository
{
    public interface IFieldMap
    {
        /// <summary>
        /// Derives the field on the Entity, which would be populated for the given controlName and controlType
        /// </summary>
        /// <param name="controlName"></param>
        /// <param name="controlType"></param>
        /// <returns></returns>
        string GetFieldNameFor(string controlName, Type controlType);
    }
}