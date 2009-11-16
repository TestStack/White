using White.Core.Factory;
using White.Core.UIItems;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Container;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;

namespace White.Core.Sessions
{
    public class NullWindowSession : WindowSession
    {
        public override WindowSession ModalWindowSession(InitializeOption modalInitializeOption)
        {
            return new NullWindowSession();
        }

        public override IUIItem Get(ContainerItemFactory containerItemFactory, SearchCriteria searchCriteria, ActionListener actionListener)
        {
            return containerItemFactory.Get(searchCriteria, actionListener);
        }

        public override void Dispose() {}

        public override void Register(Window window) {}
    }
}