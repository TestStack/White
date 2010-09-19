using System.Threading;
using Recorder.Recording;
using White.Core.UIItemEvents;
using NUnit.Framework;

namespace White.UnitTests.Recorder.Recording
{
    [TestFixture]
    public class DuplicateEventFilterTest
    {
        [Test]
        public void UseEvent()
        {
            UserEvent userEvent = new UIItemClickEvent(null);
            var filter = new DuplicateEventFilter();
            Assert.AreEqual(false, filter.UseEvent(userEvent, userEvent));
            Thread.Sleep(DuplicateEventFilter.TimeDifferenceBetweenTwoUserEvents.Milliseconds + 11);
            Assert.AreEqual(true, filter.UseEvent(new UIItemClickEvent(null), userEvent));
        }
    }
}