using System.Collections.Generic;
using Bricks.Core;
using White.Core.Configuration;
using White.Core.InputDevices;
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
            if (CoreAppXmlConfiguration.Instance.WaitBasedOnHourGlass)
            {
                Clock.Do @do = () => Mouse.Instance.Cursor;
                Clock.Matched matched = delegate(object obj)
                                            {
                                                var cursor = (MouseCursor) obj;
                                                if (MouseCursor.WaitCursors.Contains(cursor) && CoreAppXmlConfiguration.Instance.MoveMouseToGetStatusOfHourGlass)
                                                {
                                                    Mouse.Instance.MoveOut();
                                                    return false;
                                                }
                                                return true;
                                            };
                Clock.Expired expired =
                    delegate { throw new UIActionException(string.Format("Window in still wait mode. Cursor: {0}{1}", Mouse.Instance.Cursor, Constants.BusyMessage)); };
                new Clock(CoreAppXmlConfiguration.Instance.BusyTimeout).Perform(@do, matched, expired);
            }
            CustomWait(window);
            if (types.Contains(ActionType.NewControls)) window.ReloadIfCached();
        }

        public virtual void CustomWait(UIItemContainer uiItemContainer)
        {
            if (CoreAppXmlConfiguration.Instance.AdditionalWaitHook != null)
            {
                CoreAppXmlConfiguration.Instance.AdditionalWaitHook.WaitFor(uiItemContainer);
            }
        }

        public static readonly Action WindowMessage = new Action(ActionType.WindowMessage);
        public static readonly Action Scroll = new Action(ActionType.Scroll);
    }
}