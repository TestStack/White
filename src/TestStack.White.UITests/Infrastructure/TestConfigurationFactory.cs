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
                case FrameworkId.Winforms:
                    return new WinformsTestConfiguration();
                case FrameworkId.Silverlight:
                    return new SilverlightTestConfiguration();
                case FrameworkId.Win32:
                case FrameworkId.Swt:
                case FrameworkId.WinRT:
                default:
                    throw new ArgumentOutOfRangeException("framework");
            }
        }
    }
}