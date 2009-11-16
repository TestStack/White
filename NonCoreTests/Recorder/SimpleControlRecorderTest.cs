using System;
using System.Diagnostics;
using Bricks.Core;
using White.Core;
using White.Core.Factory;
using White.Core.Testing;
using White.Core.UIItems;
using White.Core.UIItems.ListBoxItems;
using White.Core.UIItems.TreeItems;
using White.Core.UIItems.WindowItems;
using NUnit.Framework;

namespace Recorder
{
    [TestFixture]
    public class SimpleControlRecorderTest : ControlsActionTest
    {
        private MultilineTextBox editor;
        private Window dashboard;
        private Application recorderApplication;

        protected override void TestFixtureSetUp()
        {
            recorderApplication = Application.Attach(Process.Start("Recorder.exe"));
            dashboard = recorderApplication.GetWindow("DashBoard", InitializeOption.NoCache);
            ListBox desktopApplications = dashboard.Get<ListBox>("applications");

            ListItem selectedApplication = desktopApplications.SelectedItem;
            if (selectedApplication.Text.Equals(application.Name))
                selectedApplication.DoubleClick();
            else
                desktopApplications.Select(application.Name);

            string text = dashboard.Get<ListBox>("windows").SelectedItemText;
            Assert.AreEqual("Form1", text);

            dashboard.Get<RadioButton>("core").Click();
            dashboard.Get<Button>("record").Click();
            editor = dashboard.Get<MultilineTextBox>("codeEditor");
        }

        private void AssertAndClearRecordedText(string expected)
        {
            WaitTill(delegate(object obj) { return S.IsNotEmpty((string)obj); });

            Assert.AreEqual(expected, editor.Text.Trim());
            ClearText();
        }

        private void WaitTill(Clock.Matched matched)
        {
            window.WaitWhileBusy();
            dashboard.WaitWhileBusy();
            Clock.Do @do = delegate { return editor.Text.Trim(); };
            Clock clock = new Clock(5000);
            Clock.Expired expired = delegate { throw new Exception(); };
            clock.Perform(@do, matched, expired);
        }

        private void ClearText()
        {
            editor.Text = string.Empty;
            WaitTill(delegate(object obj) { return S.IsEmpty((string)obj); });
        }

        [Test]
        public void ListView_SelectItem()
        {
            window.Get<ListView>("listView").Select("Key", "Search");
            AssertAndClearRecordedText("window.Get<ListView>(\"listView\").Select(\"Key\", \"Search\");");

            window.Focus();
            window.Get<ListView>("listView").Select("Key", "Search");
            AssertAndClearRecordedText("window.Get<ListView>(\"listView\").Select(\"Key\", \"Search\");");

            window.Focus();
            window.Get<ListView>("listView").Select("Key", "Mail");
            AssertAndClearRecordedText("window.Get<ListView>(\"listView\").Select(\"Key\", \"Mail\");");
        }

        [Test]
        public void ButtonClick()
        {
            window.Get<Button>("buton").Click();
            AssertAndClearRecordedText("window.Get<Button>(\"buton\").Click();");
        }

        [Test]
        public void TreeRootClick()
        {
            Tree tree = window.Get<Tree>("ped");
            Assert.IsNotNull(tree);
            TreeNode treeNode = tree.Node("Root");
            treeNode.Select();
            ClearText();
            Assert.IsFalse(treeNode.IsExpanded());
            window.Focus();
            treeNode.Expand();
            AssertAndClearRecordedText("window.Get<Tree>(\"ped\").Node(\"Root\").Expand();");
        }

        [Test]
        public void ListView_TryUnSelectAll()
        {
            ListView listView = window.Get<ListView>("listView");
            listView.Select("Key", "Search");
            ClearText();
            listView.TryUnSelectAll();
            AssertAndClearRecordedText("window.Get<ListView>(\"listView\").TryUnSelectAll();");
        }

        [Test]
        public void Text_in_TextBox()
        {
            window.Get<TextBox>("textBox").Text = "blah";
            AssertAndClearRecordedText("window.Get<TextBox>(\"textBox\").BulkText = \"blah\";");

            dashboard.Get<CheckBox>("bulkText").Checked = false;
            window.Get<TextBox>("textBoxInsidePanel").Text = "foo";
            AssertAndClearRecordedText("window.Get<TextBox>(\"textBoxInsidePanel\").Text = \"foo\";");
        }

        public override void TextFixtureTearDown()
        {
            recorderApplication.Kill();
            base.TextFixtureTearDown();
        }
    }
}