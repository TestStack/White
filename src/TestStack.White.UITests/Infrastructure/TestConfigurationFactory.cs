using System;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.Infrastructure
{
    public static class TestConfigurationFactory
    {
        public static TestConfiguration Create(WindowsFramework framework)
        {
            switch (framework.FrameworkId)
            {
                case Constants.WPFFrameworkId:
                    return new WpfTestConfiguration();
                case Constants.WinFormFrameworkId:
                    return new WinformsTestConfiguration();
                case Constants.SilverlightFrameworkId:
                    return new SilverlightTestConfiguration();
                case Constants.Win32FrameworkId:
                case Constants.SWT:
                //case Constants.WinRT:
                default:
                    throw new ArgumentOutOfRangeException("framework");
            }
        }
    }
}