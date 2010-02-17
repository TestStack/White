using System;
using System.Reflection;
using Bricks.DynamicProxy;
using Bricks.RuntimeFramework;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;
using Repository.Interceptors;
using Repository.ScreenAttributes;

namespace Repository
{
    public class ScreenClass
    {
        private readonly Class @class;
        private readonly Types nonInjectedTypes = new Types(typeof (Window), typeof (ScreenRepository));

        public ScreenClass(Class @class)
        {
            this.@class = @class;
            if (@class.NonVirtuals.Count != 0) throw AppScreenException.NonVirtualMethods(@class.NonVirtuals);
        }

        public ScreenClass(Type type) : this(new Class(type)){}

        public virtual object New(Window window, ScreenRepository screenRepository)
        {
            object o = @class.New(window, screenRepository);
            @class.EachField(delegate(FieldInfo fieldInfo)
                                 {
                                     if (nonInjectedTypes.IsAssignableFrom(fieldInfo.FieldType)) return;
                                     object injectedObject = null;
                                     if (typeof (IUIItem).IsAssignableFrom(fieldInfo.FieldType))
                                     {
                                         var interceptor = new UIItemInterceptor(SearchCondition(fieldInfo), window, screenRepository.SessionReport);
                                         injectedObject = DynamicProxyGenerator.Instance.CreateProxy(interceptor, fieldInfo.FieldType);
                                     }
                                     else if (typeof (AppScreenComponent).IsAssignableFrom(fieldInfo.FieldType))
                                     {
                                         var componentScreenClass = new ScreenClass(new Class(fieldInfo.FieldType));
                                         injectedObject = componentScreenClass.New(window, screenRepository);
                                     }

                                     if (injectedObject != null) fieldInfo.SetValue(o, injectedObject);
                                 });
            return o;
        }

        private static SearchCriteria SearchCondition(FieldInfo fieldInfo)
        {
            SearchCriteria defaultCriteria = SearchCriteria.ByAutomationId(fieldInfo.Name).AndControlType(fieldInfo.FieldType);
            SearchCriteria searchCriteria = null;
            object[] customAttributes = fieldInfo.GetCustomAttributes(false);
            foreach (Attribute customAttribute in customAttributes)
            {
                SearchCriteriaAttribute searchCriteriaAttribute = customAttribute as SearchCriteriaAttribute;
                if (searchCriteriaAttribute != null)
                {
                    if (searchCriteria == null) searchCriteria = SearchCriteria.ByControlType(fieldInfo.FieldType);
                    searchCriteriaAttribute.Apply(searchCriteria);
                }
            }
            return searchCriteria ?? defaultCriteria;
        }
    }
}