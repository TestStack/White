using System;

namespace TestStack.White.UIItems
{
    public static class WindowsFrameworkExtensions
    {
        public static bool IsManaged(this WindowsFramework framework)
        {
            return framework == WindowsFramework.WinForms || framework == WindowsFramework.Wpf;
        }

        public static string FrameworkId(this WindowsFramework framework)
        {
            var type = typeof(WindowsFramework);
            var frameworkId = framework.ToString();
            var memInfo = type.GetMember(frameworkId);

            if (memInfo.Length <= 0) return frameworkId;
            var attrs = memInfo[0].GetCustomAttributes(typeof(FrameworkIdAttribute), false);
            return attrs.Length > 0 ? ((FrameworkIdAttribute)attrs[0]).FrameworkId : frameworkId;
        }

        public static WindowsFramework FromFrameworkId(string frameworkId)
        {
            var type = typeof(WindowsFramework);
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field, typeof(FrameworkIdAttribute)) as FrameworkIdAttribute;
                if (attribute != null && attribute.FrameworkId == frameworkId)
                    return (WindowsFramework)field.GetValue(null);
                if (field.Name == frameworkId)
                    return (WindowsFramework)field.GetValue(null);
            }

            throw new ArgumentException(string.Format("'{0}' is not a valid frameworkId", frameworkId));
        }
    }
}