using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.White.Factory;
using TestStack.White.Reporting.Domain;
using TestStack.White.Sessions;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.Repository
{
    //TODO: When the window is not found the exception from screen repository should be clear enough.
    //TODO: Provide Live and FileTemplates
    //TODO: Provide method for finding window based on search criteria or make the get (match) method work, based on time
    public class ScreenRepository : IDisposable
    {
        private readonly ApplicationSession applicationSession;
        private readonly IReport sessionReport;
        private readonly ScreenRepositoryListener listener;
        private readonly Dictionary<ScreenRepositoryCacheKey, AppScreen> screenCache = new Dictionary<ScreenRepositoryCacheKey, AppScreen>();

        public delegate void ScreenAction(AppScreen appScreen);

        protected ScreenRepository() {}

        public ScreenRepository(Application application) : this(application.ApplicationSession, new NullScreenRepositoryListener(), new NullSessionReport()) {}
        
        public ScreenRepository(ApplicationSession applicationSession) : this(applicationSession, new NullScreenRepositoryListener(), new NullSessionReport()) {}

        private ScreenRepository(ApplicationSession applicationSession, ScreenRepositoryListener listener, IReport report)
        {
            this.applicationSession = applicationSession;
            this.listener = listener;
            sessionReport = report;
        }

        public ScreenRepository(ApplicationSession applicationSession, IReport sessionReport) : this(applicationSession, new NullScreenRepositoryListener(), sessionReport)
        {
        }

        public virtual ScreenRepositoryListener Listener
        {
            get { return listener; }
        }

        public virtual IReport SessionReport
        {
            get { return sessionReport; }
        }

        public virtual T Get<T>(string title, InitializeOption option) where T : AppScreen
        {
            Func<Window> window = () => applicationSession.Application.GetWindow(title, IdentifiedOption<T>(option));
            return Get<T>(title, window);
        }

        public virtual T Get<T>(SearchCriteria searchCriteria, InitializeOption option) where T : AppScreen
        {
            Func<Window> window = () => applicationSession.Application.GetWindow(searchCriteria, IdentifiedOption<T>(option));
            return Get<T>(searchCriteria.ToString(), window);
        }

        T Get<T>(string cacheKey, Func<Window> window) where T : AppScreen
        {
            ClearClosedScreens();
            AppScreen screen;
            var repositoryCacheKey = new ScreenRepositoryCacheKey(cacheKey, typeof (T));
            if (!screenCache.TryGetValue(repositoryCacheKey, out screen))
            {
                screen = GetScreen<T>(window());
                screenCache.Add(repositoryCacheKey, screen);
            }

            if (screen != null)
                sessionReport.Next(typeof (T));
            return (T) screen;
        }

        public virtual T Get<T>(Predicate<string> match, InitializeOption option) where T : AppScreen
        {
            ClearClosedScreens();
            T screen = (from pair in screenCache where pair.Key.Matches(typeof (T), match) select (T) pair.Value).FirstOrDefault();
            if (screen == null)
            {
                screen = GetScreen<T>(applicationSession.Application.Find(match, IdentifiedOption<T>(option)));
                screenCache.Add(new ScreenRepositoryCacheKey(screen.WindowTitle, typeof (T)), screen);
            }
            sessionReport.Next(typeof (T));
            return screen;
        }

        public virtual T GetModal<T>(string title, Window parentWindow, InitializeOption option) where T : AppScreen
        {
            Window window = parentWindow.ModalWindow(title, IdentifiedOption<T>(option));
            if (window != null)
                sessionReport.Next(typeof (T));
            return GetScreen<T>(window);
        }

        private void ClearClosedScreens()
        {
            var cacheKeys = (from pair in screenCache where screenCache[pair.Key].IsClosed select pair.Key).ToList();

            foreach (ScreenRepositoryCacheKey key in cacheKeys)
                screenCache.Remove(key);
        }

        private static InitializeOption IdentifiedOption<T>(InitializeOption option)
        {
            return option.AndIdentifiedBy(typeof (T).FullName);
        }

        private T GetScreen<T>(Window window) where T : AppScreen
        {
            var screenClass = new ScreenClass(typeof(T));
            return (T) screenClass.New(window, this);
        }

        public virtual void Closing(AppScreen appScreen)
        {
            sessionReport.Act();
            screenCache.Remove(new ScreenRepositoryCacheKey(appScreen.WindowTitle, appScreen.GetType()));
        }

        public virtual void Dispose()
        {
            applicationSession.Save();
            applicationSession.Dispose();
            sessionReport.Finish();
        }

        public virtual bool IsForApplication(Application application)
        {
            return ReferenceEquals(applicationSession.Application, application);
        }

        public virtual void ForEachScreen(ScreenAction screenAction)
        {
            foreach (AppScreen appScreen in screenCache.Values)
                screenAction.Invoke(appScreen);
        }
    }
}