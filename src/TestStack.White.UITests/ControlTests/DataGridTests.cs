using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UITests.ControlTests
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class DataGridTests : WhiteUITestBase
    {
        private ListView dataGridWpfUnderTest;
        private UIItems.TableItems.Table dataGridWinFormsUnderTest;

        public DataGridTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectDataGridTab();
            if (Framework == WindowsFramework.Wpf)
            {
                dataGridWpfUnderTest = MainWindow.Get<ListView>(SearchCriteria.ByAutomationId("DataGridControl"));
            }
            else if (Framework == WindowsFramework.WinForms)
            {
                dataGridWinFormsUnderTest = MainWindow.Get<UIItems.TableItems.Table>(SearchCriteria.ByAutomationId("DataGridControl"));
            }
        }

        [Test]
        public void CanGetAllItemsWpfTest()
        {
            if (Framework != WindowsFramework.Wpf)
            {
                Assert.Ignore();
            }
            var rows = dataGridWpfUnderTest.Rows;
            Assert.That(rows, Has.Count.EqualTo(3));
            var row1 = rows.Get(0);
            Assert.That(row1.Cells, Has.Count.EqualTo(4));
            Assert.That(row1.Cells[0].Text, Is.EqualTo("1"));
            Assert.That(row1.Cells[1].Text, Is.EqualTo("Item1"));
            Assert.That(row1.Cells[2].Text, Does.Contain("Simple"));
        }

        [Test]
        public void CanGetCellWpfTest()
        {
            if (Framework != WindowsFramework.Wpf)
            {
                Assert.Ignore();
            }
            Assert.That(dataGridWpfUnderTest.Cell("Contents", 0).Text, Is.EqualTo("Item1"));
            Assert.That(dataGridWpfUnderTest.Cell("Contents", 1).Text, Is.EqualTo("Item2"));
            Assert.That(dataGridWpfUnderTest.Cell("Contents", 2).Text, Is.EqualTo("Item3"));
        }

        [Test]
        public void CanGetAllItemsWinformsTest()
        {
            if (Framework != WindowsFramework.WinForms)
            {
                Assert.Ignore();
            }
            var rows = dataGridWinFormsUnderTest.Rows;
            Assert.That(rows, Has.Count.EqualTo(3));
            var row1 = rows[0];
            Assert.That(row1.Cells, Has.Count.EqualTo(3));
            Assert.That(row1.Cells[0].Value, Is.EqualTo("1"));
            Assert.That(row1.Cells[1].Value, Is.EqualTo("Item1"));
            Assert.That(row1.Cells[2].Value, Does.Contain("Simple"));
        }
    }
}
