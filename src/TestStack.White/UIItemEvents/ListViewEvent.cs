using System.Windows.Automation;
using White.Core.InputDevices;
using White.Core.UIItems;
using White.Core.UIItems.ListViewItems;
using White.Core.Utility;

namespace White.Core.UIItemEvents
{
    public class ListViewEvent : UserEvent
    {
        private static readonly string Select;
        private readonly object[] parameters;
        private static readonly string TryUnSelectAll;
        private readonly string actionName;

        static ListViewEvent()
        {
            Select = MethodNameResolver.NameFor<ListView>(l => l.Select(0));
            TryUnSelectAll = MethodNameResolver.NameFor<ListView>(l => l.TryUnSelectAll());
        }

        private ListViewEvent(IUIItem listView, string action, object[] parameters) : base(listView)
        {
            actionName = action;
            this.parameters = parameters;
        }

        protected override string ActionName(EventOption eventOption)
        {
            return actionName;
        }

        public override object[] ActionParameters
        {
            get { return parameters; }
        }

        public static UserEvent Create(ListView listView, AutomationPropertyChangedEventArgs eventArgs)
        {
            var columnPosition = (int) Mouse.instance.Location.X;
            if (listView.SelectedRows.Count == 0)
            {
                var listViewEvent = new ListViewEvent(listView, TryUnSelectAll, new object[] {});
                return listViewEvent;
            }
            if (true.Equals(eventArgs.NewValue))
            {
                string column = null;
                if (listView.Header != null)
                {
                    ListViewColumn listViewColumn =
                        listView.Header.Columns.Find(obj => obj.Bounds.Left < columnPosition && columnPosition < obj.Bounds.Right);
                    column = listViewColumn.Text;
                }
                string value = column == null ? listView.SelectedRows[0].Cells[0].Text : listView.SelectedRows[0].Cells[column].Text;
                return new ListViewEvent(listView, Select, new object[] {column, value});
            }
            return null;
        }
    }
}