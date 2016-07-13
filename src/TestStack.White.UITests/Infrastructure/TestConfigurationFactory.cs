using System;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.Infrastructure
{
    public static class TestConfigurationFactory
    {
        public static TestConfiguration Create(WindowsFramework framework)
        {
            switch (framework)
            {
                case WindowsFramework.Wpf:
                    return new WpfTestConfiguration();
                case WindowsFramework.WinForms:
                    return new WinformsTestConfiguration();
                case WindowsFramework.Win32:
                case WindowsFramework.Swt:
                //case Constants.WinRT:
                default:
                    throw new ArgumentOutOfRangeException("framework");
            }
        }
    }
}