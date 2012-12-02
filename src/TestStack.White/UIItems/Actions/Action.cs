using System.Collections.Generic;
using White.Core.UIItems.WindowItems;

namespace White.Core.UIItems.Actions
{
    public class Action
    {
        private readonly List<ActionType> types = new List<ActionType>();

        public Action(params ActionType[] actionTypes)
        {
            types.AddRange(actionTypes);
        }

        public virtual void Handle(Window window)
        {
            window.WaitWhileBusy();
            
            if (types.Contains(ActionType.NewControls)) window.ReloadIfCached();
        }

        public static readonly Action WindowMessage = new Action(ActionType.WindowMessage);
        public static readonly Action Scroll = new Action(ActionType.Scroll);
    }
}