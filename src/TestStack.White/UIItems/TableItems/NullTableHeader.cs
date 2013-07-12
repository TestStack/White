using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems.TableItems
{
    public class NullTableHeader : TableHeader
    {
        public override TableColumns Columns
        {
            get { return new TableColumns(new List<AutomationElement>(), new NullActionListener()); }
        }
    }
}