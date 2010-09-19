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
            MockRepository mocks = new MockRepository();
            T t = mocks.CreateMock<T>();
            SetupResult.For(t.PrimaryIdentification).Return(id);
            mocks.ReplayAll();
            return t;
        }

        [Test]
        public void Is_not_repeat_event_when_registering_first_event()
        {
            userAction.Register(new UIItemClickEvent(UIItem<Button>("cb")));
            Assert.AreEqual(false, userAction.RepeatEvent);
        }

        [Test]
        public void Is_not_repeat_event_when_registering_different_event()
        {
            userAction.Register(new UIItemClickEvent(UIItem<Button>("cb")));
            userAction.Register(new UIItemClickEvent(UIItem<Button>("cb")));
            Assert.AreEqual(false, userAction.RepeatEvent);
        }

        [Test]
        public void Repeat_event_when_registering_same_event()
        {
            userAction.Register(new TextBoxEvent(UIItem<TextBox>("cb")));
            userAction.Register(new TextBoxEvent(UIItem<TextBox>("cb")));
            Assert.AreEqual(true, userAction.RepeatEvent);
        }
    }
}