using System.Collections.Generic;
using System.Windows.Automation;
using Bricks.Core;
using White.Core.AutomationElementSearch;
using White.Core.Configuration;
using White.Core.Sessions;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;

namespace White.Core.Factory
{
    public abstract class ChildWindowFactory
    {
        protected readonly AutomationElementFinder finder;
        protected static readonly List<SpecializedWindowFactory> specializedWindowFactories = new List<SpecializedWindowFactory>();

        protected ChildWindowFactory(AutomationElementFinder finder)
        {
            this.finder = finder;
        }

        public virtual Window ModalWindow(string title, InitializeOption option, WindowSession windowSession)
        {
            Clock.Do @do = () => finder.FindWindow(title, 0);
            return ModalWindow(@do, option, windowSession);
        }

        private Window ModalWindow(Clock.Do find, InitializeOption option, WindowSession windowSession)
        {
            var clock = new Clock(CoreAppXmlConfiguration.Instance.BusyTimeout);
            Clock.Matched matched = obj => obj != null;
            Clock.Expired expired = () => null;
            var automationElement = (AutomationElement) clock.Perform(find, matched, expired);
            return automationElement == null ? null: Create(automationElement, option, windowSession);
        }

        public virtual Window ModalWindow(SearchCriteria searchCriteria, InitializeOption option, WindowSession windowSession)
        {
            Clock.Do @do = () => finder.FindWindow(searchCriteria);
            return ModalWindow(@do, option, windowSession);
        }

        internal static Window Create(AutomationElement element, InitializeOption option, WindowSession windowSession)
        {
            SpecializedWindowFactory specializedWindowFactory = specializedWindowFactories.Find(factory => factory.DoesSpecializedThis(element));
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