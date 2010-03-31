using NUnit.Framework;
using White.Core;
using White.Core.UIItems.TableItems;
using White.UnitTests.Core.Testing;

namespace White.UnitTests.Core.UIItems.TableItems
{
    [TestFixture, WinFormCategory]
    public class TableVerticalScrollOffsetTest : ControlsActionTest
    {
        [Test]
        public void IsInTop()
        {
            var table = window.Get<Table>("people");
            Assert.AreEqual(true, ((TableVerticalScrollOffset) table).IsOnTop);
            table.Rows[table.Rows.Count - 1].Select();
            Assert.AreEqual(false, ((TableVerticalScrollOffset)table).IsOnTop);
        }
    }
}