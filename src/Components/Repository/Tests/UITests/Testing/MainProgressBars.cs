using White.Core.UIItems;
using White.Core.UIItems.WindowItems;
using White.Repository.ScreenAttributes;
using Xunit;

namespace White.Repository.UITests.Testing
{
    [ScreenComponent]
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