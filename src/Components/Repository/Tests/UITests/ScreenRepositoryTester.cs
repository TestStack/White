using Repository;
using White.Core;
using White.Core.Factory;
using White.Core.UITests;
using White.Repository.UITests.Testing;

namespace White.Repository.UITests
{
    public class ScreenRepositoryTester
    {
        private Application application;
        private MainScreen mainScreen;

        public virtual MainScreen SetUp(InitializeOption initializeOption)
        {
            var configuration = new WinFormTestConfiguration(string.Empty);
            application = configuration.Launch();
            var screenRepository = new ScreenRepository(application.ApplicationSession);
            mainScreen = screenRepository.Get<MainScreen>("Form1", initializeOption);
            return mainScreen;
        }

        public virtual void Get()
        {
            mainScreen.ClickButton();
            mainScreen.EnterText();
            mainScreen.SelectComboBoxItem();
            mainScreen.SelectCheckbox();
            mainScreen.SelectItemInChequedListBox();
            mainScreen.SelectRadioButton();
            mainScreen.SelectItemInListBox();
            mainScreen.SelectDateTime();
            mainScreen.SelectItemInListView();
            mainScreen.LaunchModalWindow();
            mainScreen.SelectNodesInTree();
        }

        public virtual void ControlsWithSameNameAreResolvedUsingIndex()
        {
            mainScreen.SelectTab();
            mainScreen.EnterTextInTheTextBoxesWithSameNameUsingIndex();
        }

        public virtual void ComponentsAreInjected()
        {
            mainScreen.CheckProgress();
        }

        public virtual void TearDown()
        {
            application.Kill();
        }
    }
}