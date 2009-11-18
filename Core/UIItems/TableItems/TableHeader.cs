using System.Collections.Generic;
using System.Windows.Automation;
using Bricks.RuntimeFramework;
using White.Core.AutomationElementSearch;
using White.Core.Configuration;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems.TableItems
{
    public class TableHeader : UIItem
    {
        protected TableHeader() {}

        public TableHeader(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        public virtual TableColumns Columns
        {
            get
            {
                AutomationElementCollection descendants =
                    new AutomationElementFinder(automationElement).Descendants(AutomationSearchCondition.ByControlType(ControlType.Header));
                List<AutomationElement> columnElements =
                    new BricksCollection<AutomationElement>(descendants).FindAll(obj => !obj.Current.Name.StartsWith(UIItemIdAppXmlConfiguration.Instance.TableColumn));
                return new TableColumns(columnElements, actionListener);
            }
        }
    }
}