using System;
using System.Collections.Generic;

namespace White.CustomControls.Automation
{
    public interface ICommandSerializer
    {
        ICommand Deserialize(string @string);
        string Serialize(object o, List<Type> knownTypes);
    }
}