using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public virtual List<Window> DesktopWindows(Process process, ApplicationSession applicationSession)
        {
            return (from automationElement in FindAllWindowElements(process) 
                    let initializeOption = InitializeOption.NoCache 
                    select Create(automationElement, initializeOption, applicationSession.WindowSession(initializeOption)))
                    .ToList();
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
            var children = windowFinder.Children(AutomationSearchCondition.ByControlType(ControlType.Window).WithProcessId(process.Id));
            windowElements.AddRange(children);
            foreach (var automationElement in children)
                FindDescendantWindowElements(new AutomationElementFinder(automationElement), process, windowElements);
        }

        public virtual Window SplashWindow(Process process)
        {
            var automationSearchCondition = AutomationSearchCondition.ByControlType(ControlType.Pane).WithProcessId(process.Id);
            var message = "No control found matching the condition " + AutomationSearchCondition.ToString(new[] {automationSearchCondition}) + Constants.BusyMessage;
            var element = WaitTillFound(() => Finder.Child(automationSearchCondition), message);
            return new SplashWindow(element, InitializeOption.NoCache);
        }

        /// <exception cref="UIItemSearchException">if your framework is not supported</exception>
        public virtual Window CreateWindow(string title, Process process, InitializeOption option, WindowSession windowSession)
        {
            return Create(FindWindowElement(process, title), option, windowSession);
        }

        /// <exception cref="UIItemSearchException">if your framework is not supported</exception>
        public virtual Window CreateWindow(SearchCriteria searchCriteria, Process process, InitializeOption option, WindowSession windowSession)
        {
            var message = string.Format("Couldn't find window with SearchCriteria {0} in process {1}{2}", searchCriteria, process.Id, Constants.BusyMessage);
            var element = WaitTillFound(() => Finder.FindWindow(searchCriteria, process.Id), message);
            return Create(element, option, windowSession);
        }

        /// <exception cref="UIItemSearchException">if your framework is not supported</exception>
        public virtual Window FindWindow(Process process, Predicate<string> match, InitializeOption initializeOption, WindowSession windowSession)
        {
            string message = string.Format("Could not find window matching condition. ProcessName: {0}, ProcessId: {1}, MatchingConditionMethod: {2}, MatchingConditionTarget: {3}", process.ProcessName, process.Id, match.Method, match.Target);
            var foundElement = WaitTillFound(() => FindWindowElement(process, match), message);
            return Create(foundElement, initializeOption, windowSession);
        }

        private AutomationElement FindWindowElement(Process process, string title)
        {
            return WaitTillFound(() => Finder.FindWindow(title, process.Id), string.Format("Couldn't find window with title {0} in process {1}{2}", title, process.Id, ", after waiting for 30 seconds"));
        }

        private AutomationElement FindWindowElement(Process process, Predicate<string> match)
        {
            var elements = FindAllWindowElements(process);
            return elements.Find(automationElement =>
            {
                if (match.Invoke(automationElement.Current.Name)) return true;

                AutomationElement titleBarElement =
                    new AutomationElementFinder(automationElement).Child(AutomationSearchCondition.ByControlType(ControlType.TitleBar));
                if (titleBarElement == null) return false;
                return match.Invoke(titleBarElement.Current.Name);
            });
        }

        /// <exception cref="UIItemSearchException">if your framework is not supported</exception>
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

        /// <exception cref="UIItemSearchException">if your framework is not supported</exception>
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

        /// <exception cref="UIItemSearchException">if your framework is not supported</exception>
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