using System;

namespace Reporting.Domain
{
    public interface IReport
    {
        void Begin(string name);
        void Next(Type type);
        void Act();
        void Finish();
    }
}