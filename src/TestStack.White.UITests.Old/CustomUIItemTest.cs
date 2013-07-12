using System;
using System.Linq;
using System.Windows.Automation;
using NUnit.Framework;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Custom;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests
{
    [TestFixture, WinFormCategory]
    public class CustomUIItemTest : CoreTestTemplate
    {
        private Window window;

        protected override string CommandLineArguments
        {
            get { return "customcontrol"; }
        }

        protected override void BaseTestFixtureSetup()
        {
            window = Application.GetWindow("FormContainingCustomControl", InitializeOption.NoCache);
        }

        [Fact]
        public void FindCustomItem()
        {
            var myDateUIItem = window.Get<MyDateUIItem>("dateOfBirth");
            Assert.NotEqual(null, myDateUIItem);
            myDateUIItem.EnterDate(DateTime.Today);
        }

        [Test, Ignore]
        public void ItemsReturnsCustomUIItemToo()
        {
            UIItemCollection uiItemCollection = window.Items;
            Assert.Equal(true, uiItemCollection.Any(item => item is MyDateUIItem));
        }

        [Test, ExpectedException(typeof (CustomUIItemException))]
        public void NoDateUIItemMappingDefined()
        {
            window.Get<MyDateUIItemWithoutMappingDefined>("dateOfBirth");
        }

        public override void TextFixtureTearDown()
        {
            Application.Kill();
        }
    }

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