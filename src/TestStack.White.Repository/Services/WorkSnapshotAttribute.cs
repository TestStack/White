using System;

namespace TestStack.White.Repository.Services
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class WorkSnapshotAttribute : Attribute {}
}