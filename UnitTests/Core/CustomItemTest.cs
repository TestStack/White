using System;
using System.Windows.Automation;
using NUnit.Framework;
using White.Core.Factory;
using White.Core.Testing;
using White.Core.UIItems;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Custom;
using White.Core.UIItems.WindowItems;

namespace White.Core
{
    [TestFixture, WinFormCategory]
    public class CustomItemTest : CoreTestTemplate
    {
        private Window window;

        protected override string CommandLineArguments
        {
            get { return "customcontrol"; }
        }

        protected override void BaseTestFixtureSetup()
        {
            window = application.GetWindow("FormContainingCustomControl", InitializeOption.NoCache);
        }

        [Test]
        public void FindCustomItem()
        {
            var myDateUIItem = window.Get<MyDateUIItem>("dateOfBirth");
            Assert.AreNotEqual(null, myDateUIItem);
            myDateUIItem.EnterDate(DateTime.Today);
        }

        [Test, ExpectedException(typeof (CustomUIItemException))]
        public void NoDateUIItemMappingDefined()
        {
            window.Get<MyDateUIItemWithoutMappingDefined>("dateOfBirth");
        }

        public override void TextFixtureTearDown()
        {
            application.Kill();
        }
    }

    //Empty contructor with protected or public access. White creates dynamic proxy of UIItem so that common operations (aspects) can be performed
    [ControlTypeMapping(CustomUIItemType.Pane)]
    public class MyDateUIItem : CustomUIItem
    {
        public MyDateUIItem(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        protected MyDateUIItem() {}

        public virtual void EnterDate(DateTime dateTime)
        {
            Container.Get<TextBox>("day").Text = dateTime.Day.ToString();
            Container.Get<TextBox>("month").Text = dateTime.Month.ToString();
            Container.Get<TextBox>("year").Text = dateTime.Year.ToString();
        }
    }

    public class MyDateUIItemWithoutMappingDefined : CustomUIItem {}
}