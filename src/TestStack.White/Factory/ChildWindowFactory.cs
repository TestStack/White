using System;
using System.Collections.Generic;
using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.Configuration;
using White.Core.Sessions;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;
using White.Core.Utility;

namespace White.Core.Factory
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
            if (windowsFramework.WinForm) return new WinFormWindow(element, option, windowSession);
            if (windowsFramework.WPF) return new WPFWindow(element, WindowFactory.Desktop, option, windowSession);
            if (windowsFramework.Win32) return new Win32Window(element, WindowFactory.Desktop, option, windowSession);
            if (windowsFramework.UIAutomationBug) return null;
            throw new UIItemSearchException(string.Format("{0} is not supported yet.", windowsFramework));
        }
    }
}