using NUnit.Framework;
using White.Core.Configuration;

namespace White.Core.UnitTests.Configuration
{
    [TestFixture]
    public class UIItemIdAppXmlConfigurationTest
    {
        [Test]
        public void DefaultValues()
        {
            Assert.AreEqual("Vertical Scroll Bar", UIItemIdAppXmlConfiguration.Instance.TableVerticalScrollBar);
            Assert.AreEqual("Horizontal Scroll Bar", UIItemIdAppXmlConfiguration.Instance.TableHorizontalScrollBar);
            Assert.AreEqual("Row ", UIItemIdAppXmlConfiguration.Instance.TableColumn);
            Assert.AreEqual("Top Left Header Cell", UIItemIdAppXmlConfiguration.Instance.TableTopLeftHeaderCell);
            Assert.AreEqual("(null)", UIItemIdAppXmlConfiguration.Instance.TableCellNullValue);
            Assert.AreEqual("Top Row", UIItemIdAppXmlConfiguration.Instance.TableHeader);
            Assert.AreEqual("Horizontal ScrollBar", UIItemIdAppXmlConfiguration.Instance.HorizontalScrollBar);
            Assert.AreEqual("Vertical ScrollBar", UIItemIdAppXmlConfiguration.Instance.VerticalScrollBar);
        }
    }
}