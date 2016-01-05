using TestStack.White.UIItems.TabItems;
using TestStack.White.Utility;

namespace TestStack.White.UIItemEvents
{
    public class TabEvent : UserEvent
    {
        private static readonly string Action;
        private readonly object[] parameters;

        static TabEvent()
        {
            Action = MethodNameResolver.NameFor<Tab>(t => t.SelectTabPage(null));
        }

        public TabEvent(Tab tab) : base(tab)
        {
            parameters = new object[] {tab.SelectedTab.Name};
        }

        protected override string ActionName(IEventOption eventOption)
        {
            return Action;
        }

        public override object[] ActionParameters
        {
            get { return parameters; }
        }
    }
}