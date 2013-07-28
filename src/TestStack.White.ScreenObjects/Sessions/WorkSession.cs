using System;
using System.Collections.Generic;
using TestStack.White.Reporting.Domain;
using TestStack.White.ScreenObjects.Services;

namespace TestStack.White.ScreenObjects.Sessions
{
    /// <summary>
    /// Represents white session for test/automation. There should be only one instance of this.
    /// </summary>
    public class WorkSession : IDisposable
    {
        private readonly List<ScreenRepository> screenRepositories = new List<ScreenRepository>();
        private readonly IReport sessionReport;
        private readonly WhiteExecution whiteExecution;

        public WorkSession(WorkConfiguration workConfiguration, IWorkEnvironment workEnvironment)
        {
            sessionReport = workConfiguration.CreateSessionReport();
            ServiceExecution serviceExecution = ServiceExecution.Create(workEnvironment);
            whiteExecution = WhiteExecution.Create(serviceExecution, sessionReport);
            whiteExecution.ServiceExecution.RevertToSnapshot();
        }
        
        public virtual ScreenRepository Attach(Application application)
        {
            var screenRepository = new ScreenRepository(application.ApplicationSession, sessionReport);
            screenRepositories.Add(screenRepository);
            return screenRepository;
        }

        public virtual void Dispose()
        {
            screenRepositories.ForEach(obj => obj.ForEachScreen(appScreen => appScreen.Focus()));
            screenRepositories.ForEach(obj => obj.Dispose());
            whiteExecution.Dispose();
        }

        public virtual ScreenRepository Repository(Application application)
        {
            return screenRepositories.Find(obj => obj.IsForApplication(application));
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