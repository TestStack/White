using Bricks.RuntimeFramework;
using NUnit.Framework;
using Recorder;
using Reporting.Configuration;
using Repository;
using White.CustomControls.Peers.Automation;
using White.WebBrowser;

namespace White.NonCoreTests.Repository
{
    [TestFixture]
    public class NonCoreProjectsTest
    {
        [Test]
        public void AllMethodsAreVirtual()
        {
            AssemblyTest.AllMethodsVirtual(typeof (ICommand).Assembly);
            AssemblyTest.AllMethodsVirtual(typeof (RecorderForm).Assembly);
            AssemblyTest.AllMethodsVirtual(typeof (ScreenRepository).Assembly);
            AssemblyTest.AllMethodsVirtual(typeof (Firefox).Assembly);
            AssemblyTest.AllMethodsVirtual(typeof (ReportingConfiguration).Assembly);
            AssemblyTest.AllMethodsVirtual(typeof (WhitePeer).Assembly);
        }
    }
}