using System;
using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Configuration;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.TableItems;

namespace TestStack.White.Factory
{
    public class TableRowFactory
    {
        private readonly AutomationElementFinder automationElementFinder;
        private static readonly Predicate<AutomationElement> RowPredicate;

        static TableRowFactory()
        {
            RowPredicate =
                element =>
                element.Current.Name.StartsWith(UIItemIdAppXmlConfiguration.Instance.TableColumn) &&
                element.Current.Name.Split(' ').Length == 2;
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
            List<AutomationElement> descendants = automationElementFinder.Descendants(AutomationSearchCondition.ByControlType(ControlType.Custom));
            var automationElements = new List<AutomationElement>(descendants);
            return automationElements.FindAll(RowPredicate);
        }

        public virtual int NumberOfRows
        {
            get { return GetRowElements().Count; }
        }
    }
}