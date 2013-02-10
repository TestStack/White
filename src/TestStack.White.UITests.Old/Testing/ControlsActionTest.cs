using System.Configuration;
using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.WindowItems;
using White.Core.WindowsAPI;

namespace White.Core.UITests.Testing
{
    public class ControlsActionTest : CoreTestTemplate
    {
        protected const string WPFScenarioSet1 = "ScenarioSet1";
        protected const string HorizontalGridSplitter = "HorizontalGridSplitter";
        protected const string VerticalGridSplitter = "VerticalGridSplitter";

        private Label resultLabel;
        protected Window Window;
        private Label ResultLabel
        {
            get { return resultLabel ?? (resultLabel = Window.Get<Label>("result")); }
        }

        protected override void BaseTestFixtureSetup()
        {
            Window = Application.GetWindow("Form1", TestConfiguration.WindowInitializeOption);
            if (TestConfiguration is SWTTestConfiguration) resultLabel = Window.Get<Label>("result");
        }

        protected override void BaseTestFixtureTearDown()
        {
            Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.ESCAPE);
            if (Window == null)
                Application.Kill();
            else
            {
                try
                {
                    Window.Focus();
                    Window.Close();
                }
                catch
                {
                }
            }
            if (ConfigurationManager.AppSettings["SaveWindowItemsMap"] == "true") Application.ApplicationSession.Save();
            Window = null;
            resultLabel = null;
        }

        protected virtual void AssertResultLabelText(string text)
        {
            Assert.AreEqual(text, ResultLabel.Text);
        }
    }
}