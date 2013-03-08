using System;
using System.Linq;
using System.Reflection;
using White.Core.Bricks;
using White.Core.SystemExtensions;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;
using White.Repository.EntityMapping;
using White.Repository.Interceptors;
using White.Repository.ScreenAttributes;

namespace White.Repository
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
            foreach (var fieldInfo in type.GetFields(Entity.BindingFlag))
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