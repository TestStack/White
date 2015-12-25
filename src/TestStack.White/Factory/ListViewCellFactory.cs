using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.Factory
{
    public class ListViewCellFactory : UIItemFactory
    {
        private AutomationElementFinder finder;

        public virtual IUIItem Create(AutomationElement automationElement, ActionListener actionListener)
        {
            finder = new AutomationElementFinder(automationElement);
            var child = finder.Child(
                new AutomationSearchCondition(
                    new OrCondition(AutomationSearchCondition.ByControlType(ControlType.Text).Condition,
                                AutomationSearchCondition.ByControlType(ControlType.CheckBox).Condition,
                                AutomationSearchCondition.ByControlType(ControlType.ComboBox).Condition
                        )));

            return new ListViewCell(child, automationElement, actionListener);
        }
    }
}