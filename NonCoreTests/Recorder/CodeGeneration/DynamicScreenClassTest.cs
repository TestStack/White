using System;
using White.Core.UIItems;
using NUnit.Framework;

namespace Recorder.CodeGeneration
{
    [TestFixture]
    public class DynamicScreenClassTest
    {
        private DynamicScreenClass dynamicScreenClass;

        [SetUp]
        public void SetUp()
        {
            dynamicScreenClass = new DynamicScreenClass();
        }

        [Test]
        public void AddSimpleFields()
        {
            ScreenClassField classField = dynamicScreenClass.Add("foo", typeof (Button));
            AssertClassField(classField, "foo", "foo", typeof (Button), -1, false, false);
            classField = dynamicScreenClass.Add("bar", typeof (Button));
            AssertClassField(classField, "bar", "bar", typeof (Button), -1, false, false);
            classField = dynamicScreenClass.Add("coo", typeof (ListView));
            AssertClassField(classField, "coo", "coo", typeof (ListView), -1, false, false);
        }

        [Test]
        public void AddDuplicateFields()
        {
            dynamicScreenClass.Add("foo", typeof (Button));
            dynamicScreenClass.Add("foo", typeof (Button));
            int i = 0;
            dynamicScreenClass.EachField(screenClassField => AssertClassField(screenClassField, "foo", "foo" + i, typeof (Button), i++, true, false));
        }

        [Test]
        public void AddFieldsWithInvalidFieldName()
        {
            ScreenClassField screenClassField = dynamicScreenClass.Add("foo fa", typeof (Button));
            AssertClassField(screenClassField, "foo fa", "foofa", typeof(Button), -1, false, true);
        }

        [Test]
        public void AddFieldsWithInvalidFieldNameWhichAreRepeated()
        {
            dynamicScreenClass.Add("foo fa", typeof (Button));
            dynamicScreenClass.Add("foo fa", typeof (Button));
            int i = 0;
            dynamicScreenClass.EachField(
                screenClassField => AssertClassField(screenClassField, "foo fa", "foofa" + i, typeof (Button), i++, true, true));
        }

        private static void AssertClassField(ScreenClassField screenClassField, string uiItemName, string fieldName, Type type, int index, bool isIndexed,
                                      bool invalidDotNetName)
        {
            Assert.AreEqual(uiItemName, screenClassField.UIItemName);
            Assert.AreEqual(fieldName, screenClassField.FieldName);
            Assert.AreEqual(type, screenClassField.FieldType);
            Assert.AreEqual(index, screenClassField.Index);
            Assert.AreEqual(isIndexed, screenClassField.IsIndexed);
            Assert.AreEqual(invalidDotNetName, screenClassField.UIItemNameInvalidFieldName);
        }
    }
}