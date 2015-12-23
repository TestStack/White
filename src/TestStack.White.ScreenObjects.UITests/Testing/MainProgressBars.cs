using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.ScreenObjects.UITests.Testing
{
    public class MainProgressBars : AppScreenComponent
    {
        protected ProgressBar ProgressBar;

        protected MainProgressBars() {}

        public MainProgressBars(Window window, ScreenRepository screenRepository) : base(window, screenRepository) {}

        public virtual void Check()
        {
            Assert.That(ProgressBar.Value, Is.EqualTo(50));
        }
    }
}