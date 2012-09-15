using System;
using System.Collections.Generic;

namespace Reporting.Domain
{
    public class SessionReport : IReport
    {
        private readonly SubFlows subFlows;

        public SessionReport(string archiveLocation, string name)
        {
            subFlows = new SubFlows(archiveLocation, name);
        }

        public virtual IList<SubFlow> SubFlows
        {
            get { return subFlows; }
        }

        public virtual void Begin(string name)
        {
            subFlows.Begin(name);
        }

        public virtual void Next(Type type)
        {
            subFlows.Next(type);
        }

        public virtual void Act()
        {
            subFlows.Act();
        }

        public virtual bool IsEmpty
        {
            get { return subFlows.IsEmpty(); }
        }

        public virtual void Finish()
        {
            subFlows.Finish();
        }
    }
}