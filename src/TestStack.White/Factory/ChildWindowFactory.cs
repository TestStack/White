using System;
using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Configuration;
using TestStack.White.Sessions;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Utility;

namespace TestStack.White.Factory
{
    public abstract class ChildWindowFactory
    {
        protected readonly AutomationElementFinder Finder;

        protected static readonly List<SpecializedWindowFactory> SpecializedWindowFactories = new List<SpecializedWindowFactory>();

        protected ChildWindowFactory(AutomationElementFinder finder)
        {
            Finder = finder;
        }

        public virtual Window ModalWindow(string title, InitializeOption option, WindowSession windowSession)
        {
            return ModalWindow(() => Finder.FindWindow(title, 0), option, windowSession);
        }

        private static Window ModalWindow(Func<AutomationElement> find, InitializeOption option, WindowSession windowSession)
        {
            var automationElement = Retry.For(find, e => e == null, CoreAppXmlConfiguration.Instance.BusyTimeout());
            return automationElement == null ? null: Create(automationElement, option, windowSession);
        }

        public virtual Window ModalWindow(SearchCriteria searchCriteria, InitializeOption option, WindowSession windowSession)
        {
            return ModalWindow(() => Finder.FindWindow(searchCriteria), option, windowSession);
        }

        internal static Window Create(AutomationElement element, InitializeOption option, WindowSession windowSession)
        {
            SpecializedWindowFactory specializedWindowFactory = SpecializedWindowFactories.Find(factory => factory.DoesSpecializeInThis(element));
            if (specializedWindowFactory != null)
            {
                return specializedWindowFactory.Create(element, option, windowSession);
            }

            var windowsFramework = new WindowsFramework(element.Current.FrameworkId);
            if (windowsFramework.IsWinForms) return new WinFormWindow(element, option, windowSession);
            if (windowsFramework.IsWpf) return new WPFWindow(element, WindowFactory.Desktop, option, windowSession);
            if (windowsFramework.IsWin32) return new Win32Window(element, WindowFactory.Desktop, option, windowSession);
            if (windowsFramework.UIAutomationBug) return null;
            throw new UIItemSearchException(string.Format("{0} is not supported yet.", windowsFramework));
        }
    }
}