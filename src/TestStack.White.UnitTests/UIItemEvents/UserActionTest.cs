using NSubstitute;
using White.Core.UIItemEvents;
using White.Core.UIItems;
using Xunit;

namespace TestStack.White.Core.UnitTests.UIItemEvents
{
    public class UserActionTest
    {
        private readonly UserAction userAction;

        public UserActionTest()
        {
            userAction = new UserAction();
        }

        private static T UIItem<T>(string id) where T : class, IUIItem
        {
            var t = Substitute.For<T>();
            t.PrimaryIdentification.Returns(id);
            return t;
        }

        [Fact]
        public void IsNotRepeatEventWhenRegisteringFirstEvent()
        {
            userAction.Register(new UIItemClickEvent(UIItem<Button>("cb")));
            Assert.Equal(false, userAction.RepeatEvent);
        }

        [Fact]
        public void IsNotRepeatEventWhenRegisteringDifferentEvent()
        {
            userAction.Register(new UIItemClickEvent(UIItem<Button>("cb")));
            userAction.Register(new UIItemClickEvent(UIItem<Button>("cb")));
            Assert.Equal(false, userAction.RepeatEvent);
        }

        [Fact]
        public void RepeatEventWhenRegisteringSameEvent()
        {
            userAction.Register(new TextBoxEvent(UIItem<TextBox>("cb")));
            userAction.Register(new TextBoxEvent(UIItem<TextBox>("cb")));
            Assert.Equal(true, userAction.RepeatEvent);
        }
    }
}