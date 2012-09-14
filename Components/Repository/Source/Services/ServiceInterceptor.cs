using System;
using Bricks.RuntimeFramework;
using Castle.DynamicProxy;
using White.Core;
using Reporting.Domain;

namespace Repository.Services
{
    public class ServiceInterceptor : IInterceptor
    {
        private readonly Service service;
        private readonly ServiceExecution serviceExecution;
        private readonly IReport sessionReport;

        public ServiceInterceptor(Service service, ServiceExecution serviceExecution, IReport sessionReport)
        {
            this.service = service;
            this.serviceExecution = serviceExecution;
            this.sessionReport = sessionReport;
        }

        public virtual void Intercept(IInvocation invocation)
        {
            Method method = new Method(invocation.Method);
            bool snapShotEnabled = method.HasAttribute(typeof (WorkSnapshotAttribute));

            LastServiceCallStatus lastServiceCallStatus = serviceExecution.Invoking(service, invocation.Method);
            if (lastServiceCallStatus.WasExecuted)
                invocation.ReturnValue = lastServiceCallStatus.ReturnValue;
            else
            {
                if (snapShotEnabled)
                    serviceExecution.TakeSnapshot();
                ReflectedObject reflectedServiceObject = new ReflectedObject(service);
                sessionReport.Begin(invocation.Method.Name);
                try
                {
                    invocation.ReturnValue = reflectedServiceObject.Invoke(invocation.Method, invocation.Arguments);
                    serviceExecution.Invoked(invocation.ReturnValue);
                }
                catch (Exception e)
                {
                    sessionReport.Act();
                    serviceExecution.Error();
                    throw new WhiteException(string.Format("Error Invoking {0}.{1}",reflectedServiceObject.Class.Name,invocation.Method.Name),e.InnerException);
                }
            }
        }
    }
}