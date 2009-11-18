using White.Core.UIItems;
using White.Core.UIItems.WindowItems;
using NUnit.Framework;
using Repository.ScreenFieldAttributes;

namespace Repository.Testing
{
    [ScreenComponent]
    public class MainProgressBars : AppScreenComponent
    {
        private readonly ProgressBar progressBar;

        protected MainProgressBars() {}
        public MainProgressBars(Window window, ScreenRepository screenRepository) : base(window, screenRepository) {}

        public virtual void Check()
        {
            Assert.AreEqual(50, progressBar.Value);
        }
    }
}