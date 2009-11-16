using System.Collections.Generic;
using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.Factory;
using White.Core.InputDevices;
using White.Core.Sessions;
using White.Core.UIItems;
using White.Core.UIItems.Actions;
using White.Core.UIItems.ListBoxItems;
using White.Core.UIItems.WindowItems;

namespace White.Core
{
    public class Desktop : UIItemContainer
    {
        public static readonly Desktop Instance = Create();
        private readonly AutomationElementFinder finder;

        private static Desktop Create()
        {
            return new Desktop(AutomationElement.RootElement, new NullActionListener(), InitializeOption.NoCache, new NullWindowSession());
        }

        private Desktop(AutomationElement automationElement, ActionListener actionListener, InitializeOption initializeOption, WindowSession windowSession)
            : base(automationElement, actionListener, initializeOption, windowSession)
        {
            finder = new AutomationElementFinder(automationElement);
        }

        public virtual ListItems Icons
        {
            get { return IconsList.Items; }
        }

        private ListControl IconsList
        {
            get
            {
                AutomationElement element =
                    finder.Child(
                        new[]
                            {
                                AutomationSearchCondition.ByControlType(ControlType.Pane).OfName("Program Manager"),
                                AutomationSearchCondition.ByControlType(ControlType.List).OfName("Desktop")
                            });
                return new ListControl(element, new ProcessActionListener(element));
            }
        }

        public virtual void Drop(UIItem uiItem)
        {
            Mouse.DragAndDrop(uiItem, IconsList);
        }

        public virtual List<Window> Windows()
        {
            return WindowFactory.Desktop.DesktopWindows();
        }
    }
}