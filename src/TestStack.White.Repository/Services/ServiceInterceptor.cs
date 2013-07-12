using System;
using System.Linq;
using Castle.DynamicProxy;
using TestStack.White.Reporting.Domain;
using White.Core;

namespace TestStack.White.Repository.Services
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
            var workSnapshotAttributes = invocation.Method.GetCustomAttributes(typeof(WorkSnapshotAttribute), true);
            bool snapShotEnabled = workSnapshotAttributes.Any();

            LastServiceCallStatus lastServiceCallStatus = serviceExecution.Invoking(service, invocation.Method);
            if (lastServiceCallStatus.WasExecuted)
                invocation.ReturnValue = lastServiceCallStatus.ReturnValue;
            else
            {
                if (snapShotEnabled)
                    serviceExecution.TakeSnapshot();
                sessionReport.Begin(invocation.Method.Name);
                try
                {
                    invocation.ReturnValue = invocation.Method.Invoke(service, invocation.Arguments);
                    serviceExecution.Invoked(invocation.ReturnValue);
                }
                catch (Exception e)
                {
                    sessionReport.Act();
                    serviceExecution.Error();
                    throw new WhiteException(string.Format("Error Invoking {0}.{1}", service.GetType().Name, invocation.Method.Name), e.InnerException);
                }
            }
        }
    }
}