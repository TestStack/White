using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using White.Core.Configuration;
using Xstream.Core;

namespace Repository.Services
{
    public class ExecutionHistory
    {
        private object lastSnapshotId;
        private bool hasError;

        private static readonly string ExecutionHistoryFile =
    string.Format(@"{0}\{1}.xml", CoreAppXmlConfiguration.Instance.WorkSessionLocation, "ExecutionHistory");

        public ExecutionHistory()
        {
            ServiceCalls = new ServiceCalls();
        }

        public virtual void Add(ServiceCall serviceCall)
        {
            ServiceCalls.Add(serviceCall);
        }

        public virtual ServiceCalls FindCalls(ServiceCall match)
        {
            return ServiceCalls.Matching(match);
        }

        public virtual object Data { get; set; }

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
            if (File.Exists(ExecutionHistoryFile))
                return (ExecutionHistory)new FileXStream(ExecutionHistoryFile).FromFile();
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

        public virtual ServiceCalls ServiceCalls { get; private set; }

        public virtual void Save()
        {
            var fileXStream = new FileXStream(ExecutionHistoryFile);
            fileXStream.AddIgnoreAttribute(typeof(XmlIgnoreAttribute));
            fileXStream.ToXml(this);
        }

        public virtual bool DropSnapshot()
        {
            return !(hasError || lastSnapshotId == null);
        }
    }

    public class ServiceCalls : List<ServiceCall>
    {
        public ServiceCalls(IEnumerable entities) : base(entities.OfType<ServiceCall>()) {}
        public ServiceCalls() {}

        public virtual ServiceCalls Matching(ServiceCall match)
        {
            return new ServiceCalls(FindAll(obj => obj.Equals(match)));
        }
    }
}