using System;
using System.Collections.Generic;
using TestStack.White.Factory;

namespace TestStack.White.Sessions
{
    public class ApplicationSession : IDisposable
    {
        private Application application;
        private readonly Dictionary<string, WindowSession> windowSessions = new Dictionary<string, WindowSession>();

        public virtual Application Application
        {
            get { return application; }
        }

        internal virtual void Register(Application associatedApplication)
        {
            application = associatedApplication;
        }

        public virtual void Dispose()
        {
            if (!application.HasExited) application.Kill();
        }

        public virtual WindowSession WindowSession(InitializeOption initializeOption)
        {
            if (initializeOption.Identifier == null) return new NullWindowSession();

            WindowSession windowSession;
            if (windowSessions.TryGetValue(initializeOption.Identifier, out windowSession)) return windowSession;

            windowSession = new WindowSession(this, initializeOption);
            windowSessions.Add(initializeOption.Identifier, windowSession);
            return windowSession;
        }

        public virtual void Save()
        {
            foreach (WindowSession windowSession in windowSessions.Values)
                windowSession.Dispose();
        }
    }
}