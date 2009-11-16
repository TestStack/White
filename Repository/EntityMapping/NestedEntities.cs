using System;
using System.Collections.Generic;
using System.Reflection;
using Bricks.RuntimeFramework;

namespace Repository.EntityMapping
{
    [Serializable]
    public class NestedEntities : List<Entity>
    {
        public NestedEntities(Entity entity)
        {
            TraverseAndAdd(entity);
        }

        private void TraverseAndAdd(Entity entity)
        {
            if (Contains(entity)) return;

            Add(entity);
            Class @class = new Class(entity.GetType());
            @class.EachField(delegate(FieldInfo fieldInfo)
                                 {
                                     if (typeof (Entity).IsAssignableFrom(fieldInfo.FieldType))
                                     {
                                         Entity nestedEntity = fieldInfo.GetValue(entity) as Entity;
                                         if (nestedEntity != null) TraverseAndAdd(nestedEntity);
                                     }
                                 });
        }
    }
}