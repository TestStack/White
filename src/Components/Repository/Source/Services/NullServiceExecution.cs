using System.Reflection;
using Bricks.RuntimeFramework;

namespace Repository.Services
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
            return (T) new Class(typeof(T)).New(objs);
        }

        public override void RevertToSnapshot()
        {
        }
    }
}