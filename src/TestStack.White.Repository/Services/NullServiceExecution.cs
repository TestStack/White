using System;
using System.Reflection;

namespace White.Repository.Services
{
    public class NullServiceExecution : ServiceExecution
    {
        public override LastServiceCallStatus Invoking(Service service, MethodInfo methodInfo)
        {
            return new NullLastServiceCallStatus();
        }

        public override void Invoked(object returnValue)
        {
        }

        public override void TakeSnapshot()
        {
        }

        public override void Error()
        {
        }

        public override void Dispose()
        {
        }

        public override T CreateData<T>(params object[] objs)
        {
            return (T)Activator.CreateInstance(typeof(T), objs);
        }

        public override void RevertToSnapshot()
        {
        }
    }
}