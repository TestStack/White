using System;
using System.Collections.Generic;
using System.Windows.Automation;
using Bricks.Core;
using Bricks.RuntimeFramework;
using White.Core.AutomationElementSearch;
using White.Core.UIItems.Actions;
using White.Core.UIItems.TableItems;

namespace White.Core.Factory
{
    public class TableCellFactory
    {
        private readonly AutomationElement tableElement;
        private readonly ActionListener actionListener;
        private AutomationElementCollection customControlTypes;

        public TableCellFactory(AutomationElement tableElement, ActionListener actionListener)
        {
            this.tableElement = tableElement;
            this.actionListener = actionListener;
        }

        public virtual TableCells CreateCells(TableHeader tableHeader, AutomationElement rowElement)
        {
            if (customControlTypes == null)
                customControlTypes = new AutomationElementFinder(tableElement).Descendants(AutomationSearchCondition.ByControlType(ControlType.Custom));
            int zeroBasedRowNumber = int.Parse(S.LastWords(rowElement.Current.Name, 1)[0]);
            Predicate<AutomationElement> cellPredicate = delegate(AutomationElement element)
                                                             {
                                                                 string name = element.Current.Name;
                                                                 return name.Contains(" Row ") && zeroBasedRowNumber == int.Parse(S.LastWords(name, 2)[1]);
                                                             };
            List<AutomationElement> tableCellElements = new BricksCollection<AutomationElement>(customControlTypes).FindAll(cellPredicate);
            return new TableCells(tableCellElements, tableHeader, actionListener);
        }
    }
}