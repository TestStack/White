using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Automation;
using Castle.Core.Logging;
using White.Core.AutomationElementSearch;
using White.Core.Configuration;
using White.Core.Sessions;
using White.Core.UIItems;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Finders;
using White.Core.UIItems.MenuItems;
using White.Core.UIItems.WindowItems;
using White.Core.Utility;

namespace White.Core.Factory
{
    public class WindowFactory : ChildWindowFactory
    {
        private readonly ILogger logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(WindowFactory));
        private WindowFactory(AutomationElementFinder automationElementFinder) : base(automationElementFinder) {}

        public static WindowFactory Desktop
        {
            get { return new WindowFactory(new AutomationElementFinder(AutomationElement.RootElement)); }
        }

        public virtual PopUpMenu PopUp(ActionListener actionListener)
        {
            return new PopUpMenu(Finder.AutomationElement, actionListener);
        }

        private static AutomationElement WaitTillFound(Func<AutomationElement> find, string message)
        {
            var element = Retry.For(find, TimeSpan.FromSeconds(30));
            if (element == null)
                throw new UIActionException(message + Debug.GetAllWindows());
            return element;
        }

        private AutomationElement FindWindowElement(Process process, string title)
        {
            return WaitTillFound(() => Finder.FindWindow(title, process.Id), string.Format("Couldn't find window with title {0} in process {1}{2}", title, process.Id, ", after waiting for 30 seconds"));
        }

        public virtual List<Window> DesktopWindows(Process process, ApplicationSession applicationSession)
        {
            var collection = FindAllWindowElements(process);
            var list = new List<Window>();
            foreach (AutomationElement automationElement in collection)
            {
                InitializeOption initializeOption = InitializeOption.NoCache;
                list.Add(Create(automationElement, initializeOption, applicationSession.WindowSession(initializeOption)));
            }
            return list;
        }

        private List<AutomationElement> FindAllWindowElements(Process process)
        {
            var items = Retry.For(() =>
            {
                var windowElements = new List<AutomationElement>();
                FindDescendantWindowElements(Finder, process, windowElements);
                if (windowElements.Count == 0) logger.Warn("Could not find any windows for this application.");
                return windowElements;
            }, list => list.Count == 0, CoreAppXmlConfiguration.Instance.UIAutomationZeroWindowBugTimeout());

            return items ?? new List<AutomationElement>();
        }

        private void FindDescendantWindowElements(AutomationElementFinder windowFinder, Process process, List<AutomationElement> windowElements)
        {
            List<AutomationElement> children =
                windowFinder.Children(AutomationSearchCondition.ByControlType(ControlType.Window).WithProcessId(process.Id));
            windowElements.AddRange(children);
            foreach (AutomationElement automationElement in children)
                FindDescendantWindowElements(new AutomationElementFinder(automationElement), process, windowElements);
        }

        public virtual Window SplashWindow(Process process)
        {
            AutomationSearchCondition automationSearchCondition = AutomationSearchCondition.ByControlType(ControlType.Pane).WithProcessId(process.Id);
            AutomationElement element =
                WaitTillFound(() => Finder.Child(automationSearchCondition),
                              "No control found matching the condition " +
                              AutomationSearchCondition.ToString(new[] {automationSearchCondition}) + Constants.BusyMessage);
            return new SplashWindow(element, InitializeOption.NoCache);
        }

        public virtual Window CreateWindow(string title, Process process, InitializeOption option, WindowSession windowSession)
        {
            return Create(FindWindowElement(process, title), option, windowSession);
        }

        public virtual Window CreateWindow(SearchCriteria searchCriteria, Process process, InitializeOption option, WindowSession windowSession)
        {
            string message =
                string.Format("Couldn't find window with SearchCriteria {0} in process {1}{2}", searchCriteria, process.Id, Constants.BusyMessage);
            AutomationElement element = WaitTillFound(() => Finder.FindWindow(searchCriteria, process.Id), message);
            return Create(element, option, windowSession);
        }

        public virtual Window FindWindow(Process process, Predicate<string> match, InitializeOption initializeOption, WindowSession windowSession)
        {
            string message = string.Format("Could not find window matching condition. ProcessName: {0}, ProcessId: {1}, MatchingConditionMethod: {2}, MatchingConditionTarget: {3}", process.ProcessName, process.Id, match.Method, match.Target);
            AutomationElement foundElement = WaitTillFound(() => FindWindowElement(process, match), message);
            return Create(foundElement, initializeOption, windowSession);
        }

        private AutomationElement FindWindowElement(Process process, Predicate<string> match)
        {
            var elements = FindAllWindowElements(process);
            return elements.Find(delegate(AutomationElement obj)
                                     {
                                         if (match.Invoke(obj.Current.Name)) return true;

                                         AutomationElement titleBarElement =
                                             new AutomationElementFinder(obj).Child(AutomationSearchCondition.ByControlType(ControlType.TitleBar));
                                         if (titleBarElement == null) return false;
                                         return match.Invoke(titleBarElement.Current.Name);
                                     });
        }

        public virtual Window FindModalWindow(string title, Process process, InitializeOption option, AutomationElement parentWindowElement,
                                              WindowSession windowSession)
        {
            var windowFinder = new AutomationElementFinder(parentWindowElement);
            try
            {
                AutomationElement modalWindowElement = WaitTillFound(delegate
                                                                         {
                                                                             AutomationElement windowElement = windowFinder.FindWindow(title, process.Id) ??
                                                                                                               Finder.FindWindow(title, process.Id);
                                                                             return windowElement;
                                                                         }, "Could not find modal window with title: " + title);
                return Create(modalWindowElement, option, windowSession);
            }
            catch (UIActionException e)
            {
                logger.Debug(e.ToString());
                return null;
            }
        }

        public virtual Window FindModalWindow(SearchCriteria searchCriteria, InitializeOption option, AutomationElement parentWindowElement, WindowSession windowSession)
        {
            var windowFinder = new AutomationElementFinder(parentWindowElement);
            try
            {
                AutomationElement modalWindowElement = WaitTillFound(delegate
                                                                         {
                                                                             AutomationElement windowElement = windowFinder.FindWindow(searchCriteria) ??
                                                                                                               Finder.FindWindow(searchCriteria);
                                                                             return windowElement;
                                                                         }, "Could not find modal window with SearchCriteria: " + searchCriteria);
                return Create(modalWindowElement, option, windowSession);
            }
            catch (UIActionException e)
            {
                logger.Debug(e.ToString());
                return null;
            }
        }

        public virtual List<Window> DesktopWindows()
        {
            var windows = new List<Window>();
            AddWindowsBy(windows, ControlType.Window);
            AddWindowsBy(windows, ControlType.Pane);
            return windows;
        }

        private void AddWindowsBy(List<Window> windows, ControlType controlType)
        {
            List<AutomationElement> children = Finder.Children(AutomationSearchCondition.ByControlType(controlType));
            foreach (AutomationElement childElement in children)
                windows.Add(Create(childElement, InitializeOption.NoCache, new NullWindowSession()));
        }

        public static void AddSpecializedWindowFactory(SpecializedWindowFactory specializedWindowFactory)
        {
            SpecializedWindowFactories.Add(specializedWindowFactory);
        }
    }
}