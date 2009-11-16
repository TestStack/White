using White.Core;
using White.Core.Factory;
using Repository.Testing;

namespace Repository
{
    public class ScreenRepositoryTester
    {
        private Application application;
        private MainScreen mainScreen;

        public virtual MainScreen SetUp(InitializeOption initializeOption)
        {
            WinFormTestConfiguration configuration = new WinFormTestConfiguration(string.Empty);
            application = configuration.Launch();
            ScreenRepository screenRepository = new ScreenRepository(application.ApplicationSession);
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

        public virtual void Controls_with_same_name_are_resolved_using_index()
        {
            mainScreen.SelectTab();
            mainScreen.EnterTextInTheTextBoxesWithSameNameUsingIndex();
        }

        public virtual void Components_are_injected()
        {
            mainScreen.CheckProgress();
        }

        public virtual void TearDown()
        {
            application.Kill();
        }
    }
}