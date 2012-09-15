using Bricks.RuntimeFramework;
using NUnit.Framework;
using Recorder;

namespace White.Recorder.UnitTests
{
    [TestFixture]
    public class RecordCodebaseTest
    {
        [Test]
        public void AllMethodsAreVirtual()
        {
            AssemblyTest.AllMethodsVirtual(typeof(RecorderForm).Assembly);
        }
    }
}