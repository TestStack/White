using Recorder.Recording;
using White.Core.UIItems;
using White.Core.UIItems.ListBoxItems;
using NUnit.Framework;

namespace White.Recorder.UnitTests.Recording
{
    [TestFixture]
    public class CoreCodeWriterTest
    {
        private CoreCodeWriter writer;

        [SetUp]
        public void SetUp()
        {
            writer = new CoreCodeWriter();
        }

        [Test]
        public void WriteWithoutArguments()
        {
            writer.Write(typeof(Button), "Click", "buton", new string[0]);
            Assert.AreEqual("window.Get<Button>(\"buton\").Click();", writer.Code);
        }

        [Test]
        public void WriteWithArguments()
        {
            writer.Write(typeof(ComboBox), "Select", "kombo", new[]{"Arundhati Roy"});
            Assert.AreEqual("window.Get<ComboBox>(\"kombo\").Select(\"Arundhati Roy\");", writer.Code);
        }

        [Test]
        public void Write_a_property()
        {
            writer.Write(typeof(CheckBox), "Checked", "cheque", new object[]{true});
            Assert.AreEqual("window.Get<CheckBox>(\"cheque\").Checked = true;", writer.Code);
        }

        [Test]
        public void Write_a_setter_property_with_string_value()
        {
            writer.Write(typeof(TextBox), "Text", "textBox", new object[]{"blah"});
            Assert.AreEqual("window.Get<TextBox>(\"textBox\").Text = \"blah\";", writer.Code);
        }

        [Test]
        public void For_Platform_specific_core_control_type_the_writer_should_write_core_control_type()
        {
            writer.Write(typeof(WinFormTextBox), "Text", "textBox", new object[] { "blah" });
            Assert.AreEqual("window.Get<TextBox>(\"textBox\").Text = \"blah\";", writer.Code);            
        }
    }
}