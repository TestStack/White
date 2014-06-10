using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Factory;
using TestStack.White.Sessions;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;

namespace TestStack.White.UIItems.WindowItems
{
    [PlatformSpecificItem]
    public class Win32Window : Window
    {
        private readonly WindowFactory windowFactory;

        protected Win32Window() {}

        public Win32Window(AutomationElement automationElement, WindowFactory windowFactory, InitializeOption option, WindowSession windowSession)
            : base(automationElement, option, windowSession)
        {
            this.windowFactory = windowFactory;
        }

        public override T Get<T>(string primaryIdentification)
        {
            return Get<T>(SearchCriteria.ByText(primaryIdentification));
        }

        public override PopUpMenu Popup
        {
            get { return windowFactory.PopUp(this); }
        }

        public override Window ModalWindow(string title, InitializeOption option)
        {
            return windowFactory.FindModalWindow(title, Process.GetProcessById(automationElement.Current.ProcessId), option, automationElement,
                                                         WindowSession.ModalWindowSession(option));
        }

        //TODO Try and get this working
        //public override List<Window> ModalWindows()
        //{
        //    var automationSearchConditions = new AutomationSearchConditionFactory()
        //        .GetWindowSearchConditions(automationElement.Current.ProcessId)
        //        .ToArray();

        //    var descendants = new AutomationElementFinder(automationElement)
        //        .Children(automationSearchConditions);

        //    return descendants
        //        .Select(descendant => ChildWindowFactory.Create(descendant, InitializeOption.NoCache, WindowSession.ModalWindowSession(InitializeOption.NoCache)))
        //        .ToList();
        //}

        public override Window ModalWindow(SearchCriteria searchCriteria, InitializeOption option)
        {
            return windowFactory.ModalWindow(searchCriteria, option, WindowSession.ModalWindowSession(option));
        }
    }
}