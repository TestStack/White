using System;
using System.Collections.Generic;
using Bricks.DynamicProxy;
using Bricks.RuntimeFramework;
using Reporting.Configuration;
using Reporting.Domain;
using Repository.Configuration;

namespace Repository.Services
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

        public virtual void Create<T>(params object[] parameters)
        {
            if (RepositoryAppXmlConfiguration.Instance.UseHistory)
                new Class(typeof (T)).New(parameters);
        }

        public virtual T GetService<T>(params object[] objs) where T : Service
        {
            Service service;
            if (services.TryGetValue(typeof (T), out service)) return (T) service;

            Class @class = new Class(typeof (T));
            service = (T) @class.New(objs);
            if (RepositoryAppXmlConfiguration.Instance.UseHistory || ReportingAppXmlConfiguration.Instance.PublishTestReports)
            {
                service = (Service) DynamicProxyGenerator.Instance.CreateProxy(new ServiceInterceptor(service, serviceExecution, sessionReport), typeof (T));
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