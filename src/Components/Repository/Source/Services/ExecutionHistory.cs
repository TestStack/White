using System.Collections;
using System.IO;
using System.Xml.Serialization;
using Bricks.RuntimeFramework;
using White.Core.Configuration;
using Xstream.Core;

namespace Repository.Services
{
    public class ExecutionHistory
    {
        internal readonly ServiceCalls serviceCalls = new ServiceCalls();
        private object data;
        private object lastSnapshotId;
        private bool hasError;

        private static readonly string executionHistoryFile =
    string.Format(@"{0}\{1}.xml", CoreAppXmlConfiguration.Instance.WorkSessionLocation, "ExecutionHistory");

        public virtual void Add(ServiceCall serviceCall)
        {
            serviceCalls.Add(serviceCall);
        }

        public virtual ServiceCalls FindCalls(ServiceCall match)
        {
            return serviceCalls.Matching(match);
        }

        public virtual object Data
        {
            get { return data; }
            set { data = value; }
        }

        public virtual object LastSnapshot
        {
            set { lastSnapshotId = value; }
            get { return lastSnapshotId; }
        }

        public virtual bool HasError
        {
            get { return hasError; }
            set { hasError = value; }
        }

        public static ExecutionHistory Create()
        {
            if (File.Exists(executionHistoryFile))
                return (ExecutionHistory)new FileXStream(executionHistoryFile).FromFile();
            return new ExecutionHistory();
        }

        public virtual void SaveIfNoError()
        {
            if (!HasError)
            {
                lastSnapshotId = null;
                Save();
            }
        }

        public virtual ServiceCalls ServiceCalls
        {
            get { return serviceCalls; }
        }

        public virtual void Save()
        {
            var fileXStream = new FileXStream(executionHistoryFile);
            fileXStream.AddIgnoreAttribute(typeof(XmlIgnoreAttribute));
            fileXStream.ToXml(this);
        }

        public virtual bool DropSnapshot()
        {
            return !(hasError || lastSnapshotId == null);
        }
    }

    public class ServiceCalls : BricksCollection<ServiceCall>
    {
        public ServiceCalls(IEnumerable entities) : base(entities) {}
        public ServiceCalls() {}

        public virtual ServiceCalls Matching(ServiceCall match)
        {
            return new ServiceCalls(FindAll(delegate(ServiceCall obj) { return obj.Equals(match); }));
        }
    }
}