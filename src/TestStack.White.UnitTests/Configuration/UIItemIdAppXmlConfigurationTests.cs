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
            Assert.That(IUIItemIdAppXmlConfiguration.Instance.TableVerticalScrollBar, Is.EqualTo("Vertical Scroll Bar"));
            Assert.That(IUIItemIdAppXmlConfiguration.Instance.TableHorizontalScrollBar, Is.EqualTo("Horizontal Scroll Bar"));
            Assert.That(IUIItemIdAppXmlConfiguration.Instance.TableColumn, Is.EqualTo("Row "));
            Assert.That(IUIItemIdAppXmlConfiguration.Instance.TableTopLeftHeaderCell, Is.EqualTo("Top Left Header Cell"));
            Assert.That(IUIItemIdAppXmlConfiguration.Instance.TableCellNullValue, Is.EqualTo("(null)"));
            Assert.That(IUIItemIdAppXmlConfiguration.Instance.TableHeader, Is.EqualTo("Top Row"));
            Assert.That(IUIItemIdAppXmlConfiguration.Instance.HorizontalScrollBar, Is.EqualTo("Horizontal ScrollBar"));
            Assert.That(IUIItemIdAppXmlConfiguration.Instance.VerticalScrollBar, Is.EqualTo("Vertical ScrollBar"));
        }
    }
}