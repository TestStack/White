using System;
using System.Collections.Generic;
using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.UIItems.Actions;
using White.Core.UIItems.TableItems;

namespace White.Core.Factory
{
    public class TableRowFactory
    {
        private readonly AutomationElementFinder automationElementFinder;
        private static readonly Predicate<AutomationElement> RowPredicate;
        private static int result;

        static TableRowFactory()
        {
            RowPredicate =
                element =>
                element.Current.Name.Split(' ').Length == 2 &&
                // row header containes no Numbers
                (int.TryParse(element.Current.Name.Split(' ')[0], out result) ||
                int.TryParse(element.Current.Name.Split(' ')[1], out result));
        }

        public TableRowFactory(AutomationElementFinder automationElementFinder)
        {
            this.automationElementFinder = automationElementFinder;
        }

        public virtual TableRows CreateRows(ActionListener actionListener, TableHeader tableHeader)
        {
            List<AutomationElement> rowElements = GetRowElements();
            return new TableRows(rowElements, actionListener, tableHeader, new TableCellFactory(automationElementFinder.AutomationElement, actionListener));
        }

        private List<AutomationElement> GetRowElements()
        {
            // this will find only first level children of out element - rows
            List<AutomationElement> descendants = automationElementFinder.Children(AutomationSearchCondition.ByControlType(ControlType.Custom));
            var automationElements = new List<AutomationElement>(descendants.FindAll(RowPredicate));
            return automationElements;
        }

        public virtual int NumberOfRows
        {
            get { return GetRowElements().Count; }
        }
    }
}