using Bricks;
using White.Core.UIItems.TabItems;

namespace White.Core.UIItemEvents
{
    public class TabEvent : UserEvent
    {
        private static readonly string action;
        private readonly object[] parameters;

        static TabEvent()
        {
            CodePath.New<Tab>().SelectTabPage(null);
            action = CodePath.Last;
        }

        public TabEvent(Tab tab) : base(tab)
        {
            parameters = new object[] {tab.SelectedTab.Name};
        }

        protected override string ActionName(EventOption eventOption)
        {
            return action;
        }

        public override object[] ActionParameters
        {
            get { return parameters; }
        }
    }
}