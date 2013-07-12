using System.Windows.Automation;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.Factory
{
    public interface UIItemFactory
    {
        IUIItem Create(AutomationElement automationElement, ActionListener actionListener);
    }
}