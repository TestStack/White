using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TestStack.White.Bricks;
using TestStack.White.ScreenObjects.EntityMapping;
using TestStack.White.ScreenObjects.Interceptors;
using TestStack.White.ScreenObjects.ScreenAttributes;
using TestStack.White.SystemExtensions;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.ScreenObjects
{
    public class ScreenClass
    {
        private readonly Type type;
        private readonly Type[] nonInjectedTypes = new []{typeof (Window), typeof (ScreenRepository)};

        public ScreenClass(Type type)
        {
            this.type = type;
            var nonVirtuals = type.NonVirtuals().ToList();
            if (nonVirtuals.Count() != 0) throw AppScreenException.NonVirtualMethods(nonVirtuals);
        }

        public virtual object New(Window window, ScreenRepository screenRepository)
        {
            var o = Activator.CreateInstance(type, window, screenRepository);
            //Get all fields, even from base types
            var fieldInfos = AllTypes(type).SelectMany(t=>t.GetFields(Entity.BindingFlag));
            foreach (var fieldInfo in fieldInfos)
            {
                if (nonInjectedTypes.Any(t=>t.IsAssignableFrom(fieldInfo.FieldType))) continue;

                object injectedObject = null;
                if (typeof(IUIItem).IsAssignableFrom(fieldInfo.FieldType))
                {
                    var interceptor = new UIItemInterceptor(SearchCondition(fieldInfo, window.Framework), window, screenRepository.SessionReport);
                    injectedObject = DynamicProxyGenerator.Instance.CreateProxy(fieldInfo.FieldType, interceptor);
                }
                else if (typeof(AppScreenComponent).IsAssignableFrom(fieldInfo.FieldType))
                {
                    var componentScreenClass = new ScreenClass(fieldInfo.FieldType);
                    injectedObject = componentScreenClass.New(window, screenRepository);
                }

                if (injectedObject != null) fieldInfo.SetValue(o, injectedObject);
            }

            return o;
        }

        public static IEnumerable<Type> AllTypes(Type type)
        {
            yield return type;
            var baseType = type.BaseType;
            while (baseType != null)
            {
                yield return baseType;
                baseType = baseType.BaseType;
            }
        }

        private static SearchCriteria SearchCondition(FieldInfo fieldInfo, WindowsFramework framework)
        {
            SearchCriteria defaultCriteria = SearchCriteria.ByAutomationId(fieldInfo.Name).AndControlType(fieldInfo.FieldType, framework);
            SearchCriteria searchCriteria = null;
            object[] customAttributes = fieldInfo.GetCustomAttributes(false);
            foreach (Attribute customAttribute in customAttributes)
            {
                var searchCriteriaAttribute = customAttribute as SearchCriteriaAttribute;
                if (searchCriteriaAttribute != null)
                {
                    if (searchCriteria == null) searchCriteria = SearchCriteria.ByControlType(fieldInfo.FieldType, framework);
                    searchCriteriaAttribute.Apply(searchCriteria);
                }
            }
            return searchCriteria ?? defaultCriteria;
        }
    }
}