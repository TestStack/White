using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.Configuration;
using White.Core.UIItems.Actions;
using White.Core.UIItems.TableItems;

namespace White.Core.Factory
{
    public class TableCellFactory
    {
        private readonly AutomationElement tableElement;
        private readonly ActionListener actionListener;
        private List<AutomationElement> customControlTypes;

        public TableCellFactory(AutomationElement tableElement, ActionListener actionListener)
        {
            this.tableElement = tableElement;
            this.actionListener = actionListener;
        }

        public virtual TableCells CreateCells(TableHeader tableHeader, AutomationElement rowElement)
        {
            if (customControlTypes == null)
                customControlTypes = new AutomationElementFinder(tableElement).Descendants(AutomationSearchCondition.ByControlType(ControlType.Custom));
            int zeroBasedRowNumber = int.Parse(rowElement.Current.Name.Split(' ').Last());
            Predicate<AutomationElement> cellPredicate = element =>
            {
                string name = element.Current.Name;
                return name.Contains(UIItemIdAppXmlConfiguration.Instance.TableCellPrefix) &&
                       zeroBasedRowNumber == int.Parse(name.Split(' ').Last());
            };
            List<AutomationElement> tableCellElements = customControlTypes.FindAll(cellPredicate);
            return new TableCells(tableCellElements, tableHeader, actionListener);
        }
    }
}