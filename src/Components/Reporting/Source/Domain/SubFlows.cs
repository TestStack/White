using System;
using System.Collections.Generic;
using System.IO;
using log4net;

namespace Reporting.Domain
{
    public class SubFlows : List<SubFlow>
    {
        private readonly string archiveLocation;
        private readonly string flowName;
        private int currentSubFlowIndex = -1;
        private readonly ILog logger = LogManager.GetLogger(typeof(SubFlow));

        public SubFlows(string archiveLocation, string flowName)
        {
            this.archiveLocation = archiveLocation;
            this.flowName = flowName;
        }

        public virtual void Begin(string name)
        {
            Add(new SubFlow(name, flowName, archiveLocation));
            currentSubFlowIndex++;
        }

        public virtual void Next(Type type)
        {
            if (IsEmpty())
            {
                var subFlow = new SubFlow(flowName + "[" + currentSubFlowIndex + "]", flowName, archiveLocation);
                subFlow.Next(type);
                Add(subFlow);
                currentSubFlowIndex++;
                return;
            }
            this[currentSubFlowIndex].Next(type);
        }

        public virtual void Act()
        {
            if (!IsEmpty())
                this[currentSubFlowIndex].Act();
        }

        public virtual bool IsEmpty()
        {
            return Count == 0;
        }

        public virtual string FlowName
        {
            get { return flowName; }
        }

        public virtual void Finish()
        {
            ReportWriter.Write(this, archiveLocation);
            FetchErrorReportIfExists();
        }

        private void FetchErrorReportIfExists()
        {
            string errorReport = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ErrorReport.zip";
            if (File.Exists(errorReport))
            {
                logger.Info("An Error has occurred in the application. Refer " + archiveLocation + @"\ErrorReport.zip" + " for details");
                File.Move(errorReport, archiveLocation + @"\ErrorReport.zip");
            }
        }
    }
}