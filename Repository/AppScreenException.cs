using System;
using System.Reflection;
using System.Text;
using Bricks.RuntimeFramework;

namespace Repository
{
    public class AppScreenException : Exception
    {
        public AppScreenException(string message) : base(message) {}
        public AppScreenException(string message, Exception exception) : base(message, exception) {}

        public static AppScreenException NonVirtualMethods(MethodInfos methodInfos)
        {
            StringBuilder messageBuilder = new StringBuilder();
            methodInfos.ForEach(delegate(MethodInfo entity)
                                 {
                                     string message = string.Format("{0} method in class {1} is not virtual", entity.Name, entity.DeclaringType.Name);
                                     messageBuilder.AppendLine(message);
                                 });
            return new AppScreenException(messageBuilder.ToString());
        }
    }
}