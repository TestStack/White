using System;

namespace Repository.Services
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class WorkSnapshotAttribute : Attribute {}
}