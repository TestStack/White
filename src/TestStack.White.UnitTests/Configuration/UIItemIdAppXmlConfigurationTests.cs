using NUnit.Framework;
using TestStack.White.Configuration;

namespace TestStack.White.UnitTests.Configuration
{
    [TestFixture]
    public class UIItemIdAppXmlConfigurationTests
    {
        [Test]
        public void DefaultValues()
        {
            Assert.That(UIItemIdAppXmlConfiguration.Instance.TableVerticalScrollBar, Is.EqualTo("Vertical Scroll Bar"));
            Assert.That(UIItemIdAppXmlConfiguration.Instance.TableHorizontalScrollBar, Is.EqualTo("Horizontal Scroll Bar"));
            Assert.That(UIItemIdAppXmlConfiguration.Instance.TableColumn, Is.EqualTo("Row "));
            Assert.That(UIItemIdAppXmlConfiguration.Instance.TableTopLeftHeaderCell, Is.EqualTo("Top Left Header Cell"));
            Assert.That(UIItemIdAppXmlConfiguration.Instance.TableCellNullValue, Is.EqualTo("(null)"));
            Assert.That(UIItemIdAppXmlConfiguration.Instance.TableHeader, Is.EqualTo("Top Row"));
            Assert.That(UIItemIdAppXmlConfiguration.Instance.HorizontalScrollBar, Is.EqualTo("Horizontal ScrollBar"));
            Assert.That(UIItemIdAppXmlConfiguration.Instance.VerticalScrollBar, Is.EqualTo("Vertical ScrollBar"));
        }
    }
}