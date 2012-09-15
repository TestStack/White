using System.Windows.Automation;
using Bricks;
using White.Core.InputDevices;
using White.Core.UIItems;
using White.Core.UIItems.ListViewItems;

namespace White.Core.UIItemEvents
{
    public class ListViewEvent : UserEvent
    {
        private static readonly string select;
        private readonly object[] parameters;
        private static readonly string tryUnSelectAll;
        private readonly string actionName;

        static ListViewEvent()
        {
            CodePath.New<ListView>().Select(0);
            select = CodePath.Last;

            CodePath.New<ListView>().TryUnSelectAll();
            tryUnSelectAll = CodePath.Last;
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
            int columnPosition = (int) Mouse.Instance.Location.X;
            if (listView.SelectedRows.Count == 0)
            {
                ListViewEvent listViewEvent = new ListViewEvent(listView, tryUnSelectAll, new object[] {});
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
                return new ListViewEvent(listView, select, new object[] {column, value});
            }
            return null;
        }
    }
}