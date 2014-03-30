using System.Collections.Generic;
using TestStack.White.Factory;
using TestStack.White.ScreenObjects;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.UITests
{
    public class GenericScreenTypeTest : WhiteTestBase
    {
        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            var screen = Repository.Get<SomeGenericScreen<int, int>>(MainWindow.Title, InitializeOption.NoCache);
            screen.MakeWindowItemsMapDirty();
            Application.ApplicationSession.Save();
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
            yield return WindowsFramework.Wpf;
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