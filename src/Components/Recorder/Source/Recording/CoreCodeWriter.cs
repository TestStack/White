using System;
using White.Core.UIItemEvents;
using White.Core.UIItems;

namespace Recorder.Recording
{
    public class CoreCodeWriter : EventWriter
    {
        protected override string CodeForGettingUIItem(Type uiItemType, string identification)
        {
            return string.Format("window.Get<{0}>(\"{1}\")", PlatformSpecificItemAttribute.BaseType(uiItemType).Name, identification);
        }
    }
}