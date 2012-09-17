using System;
using System.Collections.Generic;
using White.Core.Configuration;
using White.Core.InputDevices;
using White.Core.UIItems.WindowItems;
using White.Core.Utility;

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
            //TODO WAIT handling is pretty busted. Should call custom hook in retry loop
            window.WaitWhileBusy();
            if (CoreAppXmlConfiguration.Instance.WaitBasedOnHourGlass)
            {
                try
                {
                    Retry.For(() => Mouse.instance.Cursor,
                          cursor =>
                          {
                              if (MouseCursor.WaitCursors.Contains(cursor))
                              {
                                  if (CoreAppXmlConfiguration.Instance.MoveMouseToGetStatusOfHourGlass)
                                    Mouse.instance.MoveOut();
                                  return true;
                              }
                              return false;
                          }, CoreAppXmlConfiguration.Instance.BusyTimeout);
                }
                catch (Exception)
                {
                    throw new UIActionException(string.Format("Window in still wait mode. Cursor: {0}{1}", Mouse.instance.Cursor, Constants.BusyMessage)); 
                }
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