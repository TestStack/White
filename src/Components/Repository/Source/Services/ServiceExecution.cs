using System;
using System.Linq;
using System.Reflection;
using White.Repository.Configuration;

namespace White.Repository.Services
{
    public class ServiceExecution
    {
        private readonly ExecutionHistory executionHistory;
        private readonly WorkEnvironment workEnvironment;
        private readonly ServiceCalls currentServiceCalls = new ServiceCalls();
        private ServiceCall currentServiceCall;
        private object o;

        protected ServiceExecution() {}

        public ServiceExecution(ExecutionHistory executionHistory, WorkEnvironment workEnvironment)
        {
            this.executionHistory = executionHistory;
            this.workEnvironment = workEnvironment;
        }

        public virtual LastServiceCallStatus Invoking(Service service, MethodInfo methodInfo)
        {
            currentServiceCall = new ServiceCall(service, methodInfo);
            ServiceCalls matchingHistoryCalls = executionHistory.FindCalls(currentServiceCall);
            ServiceCalls matchingCurrentServiceCalls = currentServiceCalls.Matching(currentServiceCall);

            if (matchingHistoryCalls.Count > matchingCurrentServiceCalls.Count)
            {
                matchingCurrentServiceCalls.Sort((x, y) => x.CallNumber.CompareTo(y.CallNumber));
                int currentCallNumberForService = matchingHistoryCalls.Last().CallNumber;
                ServiceCall matchingCall =
                    matchingHistoryCalls.Find(obj => obj.CallNumber.Equals(currentCallNumberForService));
                currentServiceCalls.Add(matchingCall);
                return new LastServiceCallStatus(matchingCall.ReturnValue);
            }
            
            currentServiceCall.CallNumber = matchingCurrentServiceCalls.Count;
            return new NullLastServiceCallStatus();
        }

        public virtual void Invoked(object returnValue)
        {
            currentServiceCall.ReturnValue = returnValue;

            executionHistory.Add(currentServiceCall);
            currentServiceCalls.Add(currentServiceCall);
            executionHistory.Save();
        }

        public virtual void TakeSnapshot()
        {
            if (executionHistory.LastSnapshot != null)
            {
                workEnvironment.DropSnapshot(executionHistory.LastSnapshot);
                executionHistory.LastSnapshot = null;
            }
            object snapshotId = workEnvironment.TakeSnapshot();
            executionHistory.LastSnapshot = snapshotId;
            executionHistory.Save();
        }

        public virtual void Error()
        {
            executionHistory.HasError = true;
        }

        public virtual void Dispose()
        {
            if (executionHistory.DropSnapshot())
                workEnvironment.DropSnapshot(executionHistory.LastSnapshot);
            executionHistory.SaveIfNoError();
        }

        public virtual T CreateData<T>(params object[] objs)
        {
            if (executionHistory.Data == null)
            {
                o = Activator.CreateInstance(typeof(T), objs);
                executionHistory.Data = o;
            }
            return (T) executionHistory.Data;
        }

        public virtual void RevertToSnapshot()
        {
            if (executionHistory.HasError) workEnvironment.RevertToSnapshot(executionHistory.LastSnapshot);
        }

        public static ServiceExecution Create(WorkEnvironment workEnvironment)
        {
            if (!RepositoryAppXmlConfiguration.Instance.UseHistory)
                return new NullServiceExecution();
            ExecutionHistory executionHistory = ExecutionHistory.Create();
            return new ServiceExecution(executionHistory, workEnvironment ?? new NullWorkEnvironment());
        }
    }
}