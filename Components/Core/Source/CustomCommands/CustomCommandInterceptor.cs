using System;
using System.IO;
using Castle.DynamicProxy;
using White.Core.UIItems;

namespace White.Core.CustomCommands
{
    public class CustomCommandInterceptor : IInterceptor
    {
        private readonly UIItem uiItem;

        public CustomCommandInterceptor(UIItem uiItem)
        {
            if (uiItem == null) throw new ArgumentNullException();
            this.uiItem = uiItem;
        }

        public virtual void Intercept(IInvocation invocation)
        {
            if (uiItem.AutomationElement == null) throw new NullReferenceException("AutomationElement in this UIItem is null");
            Type type = invocation.Method.DeclaringType;
            string assemblyFileName = new FileInfo(type.Assembly.Location).FullName;
            CustomCommandResponse response = uiItem.Do(assemblyFileName, type.FullName, invocation.Method, invocation.Arguments);
            if (response.IsException)
                throw new WhiteException(string.Format("Exception when executing command. Exception Details: {0}", response.Exception));
            invocation.ReturnValue = response.ReturnValue;
        }
    }
}