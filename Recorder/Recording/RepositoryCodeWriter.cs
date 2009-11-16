using System;
using White.Core.UIItemEvents;

namespace Recorder.Recording
{
    public class RepositoryCodeWriter : EventWriter
    {
        protected override string CodeForGettingUIItem(Type uiItemType, string identification)
        {
            return identification;
        }
    }
}