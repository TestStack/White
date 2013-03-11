using System.Windows.Forms;

namespace WindowsFormsTestApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataGridControl.DataSource = TestItems;
        }

        public TestItem[] TestItems
        {
            get
            {
                return new[]{
                               new TestItem {Id = 1, Contents = "Item1", Description = "Simple item 1"}, 
                               new TestItem {Id = 2, Contents = "Item2", Description = ""},
                               new TestItem {Id = 3, Contents = "Item3"}
                           };
            }
        }
    }
}
