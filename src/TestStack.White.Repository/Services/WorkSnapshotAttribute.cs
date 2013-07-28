using System;

namespace TestStack.White.ScreenObjects.Services
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class WorkSnapshotAttribute : Attribute {}
}