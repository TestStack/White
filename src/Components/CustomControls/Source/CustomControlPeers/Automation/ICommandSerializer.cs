using System;
using System.Collections.Generic;

namespace White.CustomControls.Peers.Automation
{
    public interface ICommandSerializer
    {
        bool TryDeserializeCommand(string @string, out ICommand command);
        string Serialize(object o, IEnumerable<Type> knownTypes);
    }
}