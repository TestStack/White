using System;

namespace TestStack.White.UITests.Infrastructure
{
    public static class TestConfigurationFactory
    {
        public static TestConfiguration Create(FrameworkId framework)
        {
            switch (framework)
            {
                case FrameworkId.Wpf:
                    return new WpfTestConfiguration();
                    break;
                case FrameworkId.Winforms:
                    return new WinformsTestConfiguration();
                    break;
                case FrameworkId.Silverlight:
                case FrameworkId.Win32:
                case FrameworkId.Swt:
                case FrameworkId.WinRT:
                default:
                    throw new ArgumentOutOfRangeException("framework");
            }
        }
    }
}