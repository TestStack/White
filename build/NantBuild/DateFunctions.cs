using System;
using NAnt.Core;
using NAnt.Core.Attributes;

namespace NantBuild
{
    [FunctionSet("date", "Date")]
    public class DateFunctions : FunctionSetBase
    {
        public DateFunctions(Project project, PropertyDictionary properties) : base(project, properties) {}

        [Function("today-to-string")]
        public string TodayToString()
        {
            return DateTime.Today.Day + "-" + DateTime.Today.Month + "-" + DateTime.Today.Year;
        }
    }
}