using System;
using System.Collections.Generic;
using System.Windows.Automation;
using Bricks.RuntimeFramework;
using White.Core.AutomationElementSearch;
using White.Core.UIItems.Actions;
using White.Core.UIItems.TableItems;

namespace White.Core.Factory
{
    public class TableRowFactory
    {
        private readonly AutomationElementFinder automationElementFinder;
        private static readonly Predicate<AutomationElement> rowPredicate;

        static TableRowFactory()
        {
            rowPredicate =
                delegate(AutomationElement element) { return element.Current.Name.StartsWith("Row ") && element.Current.Name.Split(' ').Length == 2; };
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
            AutomationElementCollection descendants = automationElementFinder.Descendants(AutomationSearchCondition.ByControlType(ControlType.Custom));
            var automationElements = new BricksCollection<AutomationElement>(descendants);
            return automationElements.FindAll(rowPredicate);
        }

        public virtual int NumberOfRows
        {
            get { return GetRowElements().Count; }
        }
    }
}