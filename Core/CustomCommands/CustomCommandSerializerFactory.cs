using System;
using White.Core.UIItems;

namespace White.Core.CustomCommands
{
    public class CustomCommandSerializerFactory
    {
        public static ICustomCommandSerializer Create(WindowsFramework windowsFramework)
        {
            if (windowsFramework.WPF)
                    return new CustomCommandSerializer();
            if (windowsFramework.Silverlight)
                    return new CustomSilverlightCommandSerializer();
            throw new NotSupportedException(string.Format("No custom command serializer for {0}", windowsFramework));
        }
    }
}