using White.Core.UIItems;
using NUnit.Framework;
using White.Recorder.CodeGeneration;

namespace Recorder.CodeGeneration
{
    [TestFixture]
    public class ScreenClassFieldTest
    {
        [Test]
        public void UIItemNameInvalidFieldName()
        {
            Assert.AreEqual(false, new ScreenClassField("abcd", typeof(Button), 0).UIItemNameInvalidFieldName);
            Assert.AreEqual(true, new ScreenClassField("abcd(", typeof(Button), 0).UIItemNameInvalidFieldName);
            Assert.AreEqual(true, new ScreenClassField("abcd egf", typeof(Button), 0).UIItemNameInvalidFieldName);
        }

        [Test]
        public void FieldName()
        {
            Assert.AreEqual("abcd0", new ScreenClassField("abcd", typeof(Button), 0).FieldName);            
            Assert.AreEqual("abcdefg0", new ScreenClassField("abcd efg", typeof(Button), 0).FieldName);            
            Assert.AreEqual("abcdefg1", new ScreenClassField("abcd efg", typeof(Button), 1).FieldName);            
            Assert.AreEqual("abcdefg", new ScreenClassField("abcd efg", typeof(Button), -1).FieldName);            
        }
    }
}