using System;
using System.Collections.Generic;
using TestStack.White.Bricks;
using TestStack.White.Reporting.Configuration;
using TestStack.White.Reporting.Domain;
using TestStack.White.ScreenObjects.Configuration;

namespace TestStack.White.ScreenObjects.Services
{
    public class WhiteExecution : IDisposable
    {
        private readonly ServiceExecution serviceExecution = new NullServiceExecution();
        private readonly IReport sessionReport = new NullSessionReport();
        private readonly Dictionary<Type, Service> services = new Dictionary<Type, Service>();

        protected WhiteExecution() {}

        public WhiteExecution(ServiceExecution serviceExecution, IReport sessionReport)
        {
            this.serviceExecution = serviceExecution;
            this.sessionReport = sessionReport;
        }

        public static WhiteExecution Create(ServiceExecution serviceExecution, IReport sessionReport)
        {
            return new WhiteExecution(serviceExecution, sessionReport);
        }

        public virtual void Dispose()
        {
            serviceExecution.Dispose();
        }

        public virtual T GetService<T>(params object[] objs) where T : Service
        {
            Service service;
            if (services.TryGetValue(typeof (T), out service)) return (T) service;

            service = (T) Activator.CreateInstance(typeof(T), objs);
            if (RepositoryConfigurationLocator.Get().UseHistory || ReportingConfigurationLocator.Get().PublishTestReports)
            {
                service = (Service) DynamicProxyGenerator.Instance.CreateProxy(typeof (T), new ServiceInterceptor(service, serviceExecution, sessionReport));
                services.Add(typeof (T), service);
            }
            return (T) service;
        }

        public virtual ServiceExecution ServiceExecution
        {
            get { return serviceExecution; }
        }
    }
}