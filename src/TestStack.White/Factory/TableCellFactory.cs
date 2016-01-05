using System;
using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Configuration;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.TableItems;

namespace TestStack.White.Factory
{
    public class TableCellFactory
    {
        private readonly AutomationElement tableElement;
        private readonly IActionListener actionListener;
        private List<AutomationElement> customControlTypes;

        public TableCellFactory(AutomationElement tableElement, IActionListener actionListener)
        {
            this.tableElement = tableElement;
            this.actionListener = actionListener;
        }

        public virtual TableCells CreateCells(TableHeader tableHeader, AutomationElement rowElement)
        {
            if (customControlTypes == null)
                customControlTypes = new AutomationElementFinder(tableElement).Descendants(AutomationSearchCondition.ByControlType(ControlType.DataItem));
            string rowNameSuffix = " " + rowElement.Current.Name;
            Predicate<AutomationElement> cellPredicate = element =>
            {
                string name = element.Current.Name;
                return name.EndsWith(rowNameSuffix);
            };
            List<AutomationElement> tableCellElements = customControlTypes.FindAll(cellPredicate);
            return new TableCells(tableCellElements, tableHeader, actionListener);
        }
    }
}