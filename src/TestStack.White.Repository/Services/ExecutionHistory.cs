using System.IO;
using System.Runtime.Serialization;
using White.Core.Configuration;

namespace TestStack.White.Repository.Services
{
    [DataContract]
    public class ExecutionHistory
    {
        [DataMember]
        private object lastSnapshotId;
        [DataMember]
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

        [DataMember]
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
            {
                using (var fs = CreateFileStream(ExecutionHistoryFile))
                {
                    var dcs = new DataContractSerializer(typeof (ExecutionHistory));
                    return (ExecutionHistory)dcs.ReadObject(fs);
                }
            }
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
            using (var fs = CreateFileStream(ExecutionHistoryFile))
            {
                var dcs = new DataContractSerializer(typeof(ExecutionHistory));
                dcs.WriteObject(fs, this);
            }
        }

        private static FileStream CreateFileStream(string fileLocation)
        {
            return new FileStream(fileLocation, FileMode.OpenOrCreate);
        }

        public virtual bool DropSnapshot()
        {
            return !(hasError || lastSnapshotId == null);
        }
    }
}