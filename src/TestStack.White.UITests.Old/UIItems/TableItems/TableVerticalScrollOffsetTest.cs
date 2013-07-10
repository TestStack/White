using NUnit.Framework;
using White.Core.UIItems.TableItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.TableItems
{
    [TestFixture, WinFormCategory]
    public class TableVerticalScrollOffsetTest : ControlsActionTest
    {
        [Fact]
        public void IsInTop()
        {
            var table = Window.Get<Table>("people");
            Assert.Equal(true, ((TableVerticalScrollOffset) table).IsOnTop);
            table.Rows[table.Rows.Count - 1].Select();
            Assert.Equal(false, ((TableVerticalScrollOffset)table).IsOnTop);
        }
    }
}