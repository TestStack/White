using NUnit.Framework;
using TestStack.White.UITests.Infrastructure;

namespace TestStack.White.UITests
{
    public class ApplicationTest : WhiteTestBase
    {
        [TestCase(FrameworkId.Wpf)]
        [TestCase(FrameworkId.Winforms)]
        public void Test(FrameworkId frameworkId)
        {
            var window = GetMainWindow(frameworkId);
        }
    }
}