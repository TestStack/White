using White.Core.Configuration;
using Xunit;

namespace TestStack.White.Core.UnitTests.Configuration
{
    public class UIItemIdAppXmlConfigurationTest
    {
        [Fact]
        public void DefaultValues()
        {
            Assert.Equal("Vertical Scroll Bar", UIItemIdAppXmlConfiguration.Instance.TableVerticalScrollBar);
            Assert.Equal("Horizontal Scroll Bar", UIItemIdAppXmlConfiguration.Instance.TableHorizontalScrollBar);
            Assert.Equal("Row ", UIItemIdAppXmlConfiguration.Instance.TableColumn);
            Assert.Equal("Top Left Header Cell", UIItemIdAppXmlConfiguration.Instance.TableTopLeftHeaderCell);
            Assert.Equal("(null)", UIItemIdAppXmlConfiguration.Instance.TableCellNullValue);
            Assert.Equal("Top Row", UIItemIdAppXmlConfiguration.Instance.TableHeader);
            Assert.Equal("Horizontal ScrollBar", UIItemIdAppXmlConfiguration.Instance.HorizontalScrollBar);
            Assert.Equal("Vertical ScrollBar", UIItemIdAppXmlConfiguration.Instance.VerticalScrollBar);
        }
    }
}