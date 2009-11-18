using System.Configuration;
using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.WindowItems;
using White.Core.WindowsAPI;

namespace White.Core.Testing
{
    public class ControlsActionTest : CoreTestTemplate
    {
        protected const string WPFScenarioSet1 = "ScenarioSet1";
        protected const string HorizontalGridSplitter = "HorizontalGridSplitter";
        protected const string VerticalGridSplitter = "VerticalGridSplitter";

        private Label resultLabel;
        protected Window window;
        private Label ResultLabel
        {
            get
            {
                if (resultLabel == null) resultLabel = window.Get<Label>("result");
                return resultLabel;
            }
        }

        protected override void BaseTestFixtureSetup()
        {
            window = application.GetWindow("Form1", testConfiguration.WindowInitializeOption);
            if (testConfiguration is SWTTestConfiguration) resultLabel = window.Get<Label>("result");
        }

        protected override void BaseTestFixtureTearDown()
        {
            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.ESCAPE);
            if (window == null)
                application.Kill();
            else
            {
                try
                {
                    window.Focus();
                    window.Close();
                }
                catch {}
            }
            if (ConfigurationManager.AppSettings["SaveWindowItemsMap"] == "true") application.ApplicationSession.Save();
            window = null;
            resultLabel = null;
        }

        protected virtual void AssertResultLabelText(string text)
        {
            Assert.AreEqual(text, ResultLabel.Text);
        }
    }
}