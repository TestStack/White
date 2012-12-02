using System;
using White.Core.UIItems.Custom;

namespace White.Core.UIItems.Finders
{
    public static class TestControlTypeX
    {
        public static bool IsCustomType(this Type type)
        {
            return typeof (CustomUIItem).IsAssignableFrom(type);
        }
    }
}