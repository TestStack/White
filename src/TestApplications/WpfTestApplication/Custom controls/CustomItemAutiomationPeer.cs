using System.Windows.Automation.Peers;

namespace WpfTestApplication
{
    public class CustomItemAutiomationPeer : UIElementAutomationPeer
    {
        private readonly CustomItem _customItem;

        public CustomItemAutiomationPeer(CustomItem customItem)
            : base (customItem)
        {
            _customItem = customItem;
        }

        protected override string GetClassNameCore()
        {
            return _customItem.GetType().Name;
        }

        protected override string GetNameCore()
        {
            return _customItem.Name;
        }

        protected override string GetAutomationIdCore()
        {
            return _customItem.GetType().Name;
        }
    }
}