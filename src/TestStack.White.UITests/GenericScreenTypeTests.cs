using NUnit.Framework;
using TestStack.White.Factory;
using TestStack.White.ScreenObjects;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.UITests
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class GenericScreenTypeTests : WhiteUITestBase
    {
        public GenericScreenTypeTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [Test]
        public void ExecuteTest()
        {
            Assert.That(() =>
            {
                var screen = Repository.Get<SomeGenericScreen<int, int>>(MainWindow.Title, InitializeOption.NoCache);
                screen.MakeWindowItemsMapDirty();
                Application.ApplicationSession.Save();
            }, Throws.Nothing);
        }

        private class SomeGenericScreen<T1, T2> : AppScreen
        {
            private readonly Window window;

            public SomeGenericScreen(Window window, ScreenRepository screenRepository)
                : base(window, screenRepository)
            {
                this.window = window;
            }

            public virtual void MakeWindowItemsMapDirty()
            {
                window.Get(SearchCriteria.All);
            }
        }
    }
}