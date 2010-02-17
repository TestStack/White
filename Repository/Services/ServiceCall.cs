using System;
using System.Reflection;

namespace Repository.Services
{
    public class ServiceCall : IEquatable<ServiceCall>
    {
        private readonly string methodName;
        private readonly string[] parameterTypes;
        private readonly string serviceName;
        private int callNumber;
        private object returnValue;

        protected ServiceCall() {}

        public ServiceCall(Service service, MethodInfo methodInfo)
        {
            serviceName = service.GetType().FullName;
            methodName = methodInfo.Name;
            ParameterInfo[] parameters = methodInfo.GetParameters();
            parameterTypes = new string[parameters.Length];
            int i = 0;
            foreach (ParameterInfo parameterInfo in parameters)
                parameterTypes[i++] = parameterInfo.ParameterType.FullName;
        }

        public virtual int CallNumber
        {
            get { return callNumber; }
            set { callNumber = value; }
        }

        public virtual object ReturnValue
        {
            get { return returnValue; }
            set { returnValue = value; }
        }

        public virtual string[] ParameterTypes
        {
            get { return parameterTypes; }
        }

        public virtual bool Equals(ServiceCall serviceCall)
        {
            if (serviceCall == null) return false;
            if (!Equals(methodName, serviceCall.methodName)) return false;
            for (int i = 0; i < parameterTypes.Length; i++)
                if (!Equals(parameterTypes[i], serviceCall.parameterTypes[i])) return false;
            if (!Equals(serviceName, serviceCall.serviceName)) return false;
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ServiceCall);
        }

        public override int GetHashCode()
        {
            int result = methodName == null ? 0 : methodName.GetHashCode();
            result = 29*result + (parameterTypes == null ? 0 : parameterTypes.GetHashCode());
            result = 29*result + (serviceName == null ? 0 : serviceName.GetHashCode());
            return result;
        }
    }
}