using System;
using TestStack.White.Factory;
using TestStack.White.Repository.UITests.Testing;
using TestStack.White.UITests.Infrastructure;

namespace TestStack.White.Repository.UITests
{
    public class ScreenRepositoryTester : IDisposable
    {
        private Application application;
        private MainScreen mainScreen;

        public virtual MainScreen SetUp(InitializeOption initializeOption)
        {
            application = new WinformsTestConfiguration().LaunchApplication();
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
            //mainScreen.SelectItemInChequedListBox();
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

        public virtual void Dispose()
        {
            application.Kill();
        }
    }
}