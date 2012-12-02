using NUnit.Framework;
using Rhino.Mocks;
using White.Core.UIItemEvents;
using White.Core.UIItems;

namespace White.Core.UnitTests.UIItemEvents
{
    [TestFixture, Category("Normal")]
    public class UserActionTest
    {
        private UserAction userAction;

        [SetUp]
        public void SetUp()
        {
            userAction = new UserAction();
        }

        private static T UIItem<T>(string id) where T : IUIItem
        {
            var mocks = new MockRepository();
            var t = mocks.StrictMock<T>();
            SetupResult.For(t.PrimaryIdentification).Return(id);
            mocks.ReplayAll();
            return t;
        }

        [Test]
        public void IsNotRepeatEventWhenRegisteringFirstEvent()
        {
            userAction.Register(new UIItemClickEvent(UIItem<Button>("cb")));
            Assert.AreEqual(false, userAction.RepeatEvent);
        }

        [Test]
        public void IsNotRepeatEventWhenRegisteringDifferentEvent()
        {
            userAction.Register(new UIItemClickEvent(UIItem<Button>("cb")));
            userAction.Register(new UIItemClickEvent(UIItem<Button>("cb")));
            Assert.AreEqual(false, userAction.RepeatEvent);
        }

        [Test]
        public void RepeatEventWhenRegisteringSameEvent()
        {
            userAction.Register(new TextBoxEvent(UIItem<TextBox>("cb")));
            userAction.Register(new TextBoxEvent(UIItem<TextBox>("cb")));
            Assert.AreEqual(true, userAction.RepeatEvent);
        }
    }
}