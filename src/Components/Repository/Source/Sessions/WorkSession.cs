using System;
using Bricks.RuntimeFramework;
using White.Core;
using Reporting.Domain;
using Repository.Services;

namespace Repository.Sessions
{
    /// <summary>
    /// Represents white session for test/automation. There should be only one instance of this.
    /// </summary>
    public class WorkSession : IDisposable
    {
        private readonly BricksCollection<ScreenRepository> screenRepositories = new BricksCollection<ScreenRepository>();
        private readonly IReport sessionReport;
        private readonly WhiteExecution whiteExecution;

        public WorkSession(WorkConfiguration workConfiguration, WorkEnvironment workEnvironment)
        {
            sessionReport = workConfiguration.CreateSessionReport();
            ServiceExecution serviceExecution = ServiceExecution.Create(workEnvironment);
            whiteExecution = WhiteExecution.Create(serviceExecution, sessionReport);
            whiteExecution.ServiceExecution.RevertToSnapshot();
        }
        
        public virtual void Attach(Application application)
        {
            screenRepositories.Add(new ScreenRepository(application.ApplicationSession, sessionReport));
        }

        public virtual void Dispose()
        {
            screenRepositories.ForEach(obj => obj.ForEachScreen(appScreen => appScreen.Focus()));
            screenRepositories.ForEach(obj => obj.Dispose());
            whiteExecution.Dispose();
        }

        public virtual ScreenRepository Repository(Application application)
        {
            return screenRepositories.Find(delegate(ScreenRepository obj) { return obj.IsForApplication(application); });
        }

        public virtual T GetService<T>(params object[] objs) where T : Service
        {
            return whiteExecution.GetService<T>(objs);
        }

        public virtual T CreateData<T>(params object[] objs)
        {
            return whiteExecution.ServiceExecution.CreateData<T>(objs);
        }
    }
}