using System;
using System.Collections.Generic;

namespace TestStack.White.Repository.EntityMapping
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
            var entityType = entity.GetType();
            foreach (var fieldInfo in entityType.GetFields(Entity.BindingFlag))
            {
                if (typeof(Entity).IsAssignableFrom(fieldInfo.FieldType))
                {
                    var nestedEntity = fieldInfo.GetValue(entity) as Entity;
                    if (nestedEntity != null) TraverseAndAdd(nestedEntity);
                }
            }
        }
    }
}