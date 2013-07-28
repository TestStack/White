using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using Xunit;

namespace TestStack.White.ScreenObjects.UITests.Testing
{
    public class MainProgressBars : AppScreenComponent
    {
        protected ProgressBar ProgressBar;

        protected MainProgressBars() {}
        public MainProgressBars(Window window, ScreenRepository screenRepository) : base(window, screenRepository) {}

        public virtual void Check()
        {
            Assert.Equal(50, ProgressBar.Value);
        }
    }
}