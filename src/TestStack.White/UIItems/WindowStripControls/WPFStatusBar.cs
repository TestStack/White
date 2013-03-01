using System.Linq;
using System.Windows.Automation;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Finders;

namespace White.Core.UIItems.WindowStripControls
{
    public class WPFStatusBar : UIItem
    {
        protected WPFStatusBar() {}
        public WPFStatusBar(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        public virtual UIItemCollection Items
        {
            get
            {
                var uiItemCollection = factory.CreateAll(SearchCriteria.All, ActionListener)
                    .Where(i=>i.AutomationElement.Current.ClassName == "StatusBarItem");
                return new UIItemCollection(uiItemCollection);
            }
        }
    }
}