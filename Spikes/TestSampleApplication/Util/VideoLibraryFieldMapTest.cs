using Core.UIItems;
using NUnit.Framework;

namespace TestSampleApplication.Util
{
    [TestFixture]
    public class VideoLibraryFieldMapTest
    {
        [Test]
        public void GetFieldNameFor()
        {
            VideoLibraryFieldMap fieldMap = new VideoLibraryFieldMap();
            Assert.AreEqual("name", fieldMap.GetFieldNameFor("nameTextbox", typeof(TextBox)));
        }
    }
}