using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.TableItems;

namespace TestStack.White.Factory
{
    public class TableRowFactory
    {
        private readonly AutomationElementFinder automationElementFinder;        

        public TableRowFactory(AutomationElementFinder automationElementFinder)
        {
            this.automationElementFinder = automationElementFinder;
        }

        public virtual int NumberOfRows
        {
            get { return GetRowElements().Count; }
        }

        public virtual TableRows CreateRows(IActionListener actionListener, TableHeader tableHeader)
        {
            var rowElements = GetRowElements();
            return new TableRows(rowElements, actionListener, tableHeader, new TableCellFactory(automationElementFinder.AutomationElement, actionListener));
        }

        private List<AutomationElement> GetRowElements()
        {
            // this will find only first level children of out element - rows
            var descendants = automationElementFinder.Children(AutomationSearchCondition.ByControlType(ControlType.Custom));
            var automationElements = new List<AutomationElement>(descendants.FindAll(IsRow));
            return automationElements;
        }

        private static bool IsRow(AutomationElement element)
        {
            var parts = element.Current.Name.Split(' ');

            if (parts.Length < 2)
            {
                return false;
            }

            int result;

            for (var i = parts.Length - 1; i >= 0; i--)
            {
                if (int.TryParse(parts[i], out result))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
