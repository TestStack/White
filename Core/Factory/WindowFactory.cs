using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Automation;
using Bricks.Core;
using Bricks.RuntimeFramework;
using White.Core.AutomationElementSearch;
using White.Core.Configuration;
using White.Core.Logging;
using White.Core.Sessions;
using White.Core.UIItems;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Finders;
using White.Core.UIItems.MenuItems;
using White.Core.UIItems.WindowItems;

namespace White.Core.Factory
{
    public class WindowFactory : ChildWindowFactory
    {
        private WindowFactory(AutomationElementFinder automationElementFinder) : base(automationElementFinder) {}

        public static WindowFactory Desktop
        {
            get { return new WindowFactory(new AutomationElementFinder(AutomationElement.RootElement)); }
        }

        public virtual PopUpMenu PopUp(ActionListener actionListener)
        {
            return new PopUpMenu(finder.AutomationElement, actionListener);
        }

        private static AutomationElement WaitTillFound(Clock.Do find, string message)
        {
            var clock = new Clock(CoreAppXmlConfiguration.Instance.BusyTimeout);
            Clock.Matched matched = obj => obj != null;
            Clock.Expired expired = delegate { throw new UIActionException(message + Debug.GetAllWindows()); };
            return (AutomationElement) clock.Perform(find, matched, expired);
        }

        private AutomationElement FindWindowElement(Process process, string title)
        {
            Clock.Do find = () => finder.FindWindow(title, process.Id);
            return WaitTillFound(find, string.Format("Couldn't find window with title {0} in process {1}{2}", title, process.Id, Constants.BusyMessage));
        }

        public virtual List<Window> DesktopWindows(Process process, ApplicationSession applicationSession)
        {
            BricksCollection<AutomationElement> collection = FindAllWindowElements(process);
            var list = new List<Window>();
            foreach (AutomationElement automationElement in collection)
            {
                InitializeOption initializeOption = InitializeOption.NoCache;
                list.Add(Create(automationElement, initializeOption, applicationSession.WindowSession(initializeOption)));
            }
            return list;
        }

        private BricksCollection<AutomationElement> FindAllWindowElements(Process process)
        {
            var clock = new Clock(CoreAppXmlConfiguration.Instance.UIAutomationZeroWindowBugTimeout, 200);
            Clock.Do @do = delegate
                               {
                                   var windowElements = new BricksCollection<AutomationElement>();
                                   FindChildWindowElements(finder, process, windowElements);
                                   if (windowElements.Count == 0) WhiteLogger.Instance.Warn("Could not find any windows for this application.");
                                   return windowElements;
                               };
            Clock.Matched matched = obj => ((BricksCollection<AutomationElement>) obj).Count > 0;
            Clock.Expired expired = () => new BricksCollection<AutomationElement>();

            return (BricksCollection<AutomationElement>) clock.Perform(@do, matched, expired);
        }

        private void FindChildWindowElements(AutomationElementFinder windowFinder, Process process, BricksCollection<AutomationElement> windowElements)
        {
            AutomationElementCollection children =
                windowFinder.Children(AutomationSearchCondition.ByControlType(ControlType.Window).WithProcessId(process.Id));
            windowElements.AddRange(children);
            foreach (AutomationElement automationElement in children)
                FindChildWindowElements(new AutomationElementFinder(automationElement), process, windowElements);
        }

        public virtual Window SplashWindow(Process process)
        {
            AutomationSearchCondition automationSearchCondition = AutomationSearchCondition.ByControlType(ControlType.Pane).WithProcessId(process.Id);
            Clock.Do find = () => finder.Child(automationSearchCondition);
            AutomationElement element =
                WaitTillFound(find,
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
            Clock.Do find = () => finder.FindWindow(searchCriteria, process.Id);
            string message =
                string.Format("Couldn't find window with SearchCriteria {0} in process {1}{2}", searchCriteria, process.Id, Constants.BusyMessage);
            AutomationElement element = WaitTillFound(find, message);
            return Create(element, option, windowSession);
        }

        public virtual Window FindWindow(Process process, Predicate<string> match, InitializeOption initializeOption, WindowSession windowSession)
        {
            AutomationElement foundElement =
                WaitTillFound(() => FindWindowElement(process, match), "Could not find window matching condition");
            return Create(foundElement, initializeOption, windowSession);
        }

        private AutomationElement FindWindowElement(Process process, Predicate<string> match)
        {
            BricksCollection<AutomationElement> elements = FindAllWindowElements(process);
            return elements.Find(delegate(AutomationElement obj)
                                     {
                                         if (match.Invoke(obj.Current.Name)) return true;

                                         AutomationElement titleBarElement =
                                             new AutomationElementFinder(obj).Child(AutomationSearchCondition.ByControlType(ControlType.TitleBar));
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
                                                                                                               finder.FindWindow(title, process.Id);
                                                                             return windowElement;
                                                                         }, "Could not find modal window with title: " + title);
                return Create(modalWindowElement, option, windowSession);
            }
            catch (UIActionException e)
            {
                WhiteLogger.Instance.Debug(e.ToString());
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
                                                                                                               finder.FindWindow(searchCriteria);
                                                                             return windowElement;
                                                                         }, "Could not find modal window with SearchCriteria: " + searchCriteria);
                return Create(modalWindowElement, option, windowSession);
            }
            catch (UIActionException e)
            {
                WhiteLogger.Instance.Debug(e.ToString());
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
            AutomationElementCollection children = finder.Children(AutomationSearchCondition.ByControlType(controlType));
            foreach (AutomationElement childElement in children)
                windows.Add(Create(childElement, InitializeOption.NoCache, new NullWindowSession()));
        }

        public static void AddSpecializedWindowFactory(SpecializedWindowFactory specializedWindowFactory)
        {
            specializedWindowFactories.Add(specializedWindowFactory);
        }
    }
}