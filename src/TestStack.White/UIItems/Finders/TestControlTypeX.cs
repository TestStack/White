using System;
using TestStack.White.UIItems.Custom;

namespace TestStack.White.UIItems.Finders
{
    public static class TestControlTypeX
    {
        public static bool IsCustomType(this Type type)
        {
            return typeof (CustomUIItem).IsAssignableFrom(type);
        }
    }
}