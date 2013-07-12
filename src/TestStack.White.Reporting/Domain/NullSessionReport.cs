using System;

namespace Reporting.Domain
{
    public class NullSessionReport : IReport
    {
        public virtual void Begin(string name) { }
        public virtual void Next(Type type) { }
        public virtual void Act() { }
        public virtual void Finish() { }
    }
}