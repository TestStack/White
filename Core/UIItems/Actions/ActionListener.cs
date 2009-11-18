namespace White.Core.UIItems.Actions
{
    public interface ActionListener
    {
        void ActionPerforming(UIItem uiItem);
        void ActionPerformed(Action action);
    }

    public class NullActionListener : ActionListener
    {
        public virtual void ActionPerforming(UIItem uiItem) {}

        public virtual void ActionPerformed(Action action) {}
    }

    public delegate void VoidDelegate();
}