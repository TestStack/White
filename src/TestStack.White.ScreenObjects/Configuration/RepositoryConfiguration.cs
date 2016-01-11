using System.Collections.Generic;
using System.IO;
using TestStack.White.Configuration;

namespace TestStack.White.ScreenObjects.Configuration
{
    public class RepositoryConfiguration : ConfigurationBase
    {
        private const string RecordFlowKey = "RecordFlow";
        private const string ServiceCallHistoryLocationKey = "ServiceCallHistoryLocation";
        private const string UseHistoryKey = "UseHistory";

        public bool RecordFlow
        {
            get { return GetValueBoolean(RecordFlowKey); }
            set { SetValue(RecordFlowKey, value); }
        }

        public DirectoryInfo ServiceCallHistoryLocation
        {
            get { return new DirectoryInfo(GetValue(ServiceCallHistoryLocationKey)); }
            set { SetValue(ServiceCallHistoryLocationKey, value); }
        }

        public bool UseHistory
        {
            get { return GetValueBoolean(UseHistoryKey); }
            set { SetValue(UseHistoryKey, value); }
        }

        public override Dictionary<string, object> DefaultValues
        {
            get
            {
                return new Dictionary<string, object>
                {
                    {RecordFlowKey, false},
                    {ServiceCallHistoryLocationKey, "."},
                    {UseHistoryKey, false}
                };
            }
        }
    }
}
