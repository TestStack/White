using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace WindowsPresentationFramework
{
    /// <summary>
    /// Interaction logic for ScenarioSet1.xaml
    /// </summary>
    public partial class ScenarioSet1
    {
        public ScenarioSet1()
        {
            InitializeComponent();
            comboBox1.Items.Add("A");
            comboBox1.Items.Add("B");
            comboBox1.Items.Add("C");
            comboBox1.Items.Add("D");
            comboBox1.Items.Add("E");
            comboBox1.Items.Add("G");
            comboBox1.Items.Add("H");
            comboBox1.Items.Add("I");
            comboBox1.Items.Add("J");
            comboBox1.Items.Add("K");
            comboBox1.Items.Add("L");
            comboBox1.Items.Add("M");
            comboBox1.Items.Add("N");
            comboBox1.Items.Add("O");
            comboBox1.Items.Add("P");
            comboBox1.Items.Add("Q");
            comboBox1.Items.Add("R");
            comboBox1.Items.Add("S");
            comboBox1.Items.Add("T");
            comboBox1.Items.Add("U");
            comboBox1.Items.Add("V");
            comboBox1.Items.Add("W");
            comboBox1.Items.Add("X");
            comboBox1.Items.Add("Y");
            comboBox1.Items.Add("Z");

            Screen[] screens = Screen.AllScreens;
            Top = screens[0].Bounds.Bottom - Height - 100;

            var myDataSet = new DataSet();
            var table = new DataTable {TableName = "Employees"};
            myDataSet.Tables.Add(table);
            dataBoundComboBox.ItemsSource = GetList();
            dataBoundComboBox.DisplayMemberPath = "EmployeeName";
            dataBoundComboBox.SelectedIndex = 0;

            editableComboBox.Items.Add("whatever");
            editableComboBox.IsEditable = true;
        }

        private static IList GetList()
        {
            var list = new ArrayList();
            var employee = new TestEmployee {EmployeeName = "S P Kumar"};
            list.Add(employee);
            return list;
        }
    }

    public class TestEmployee
    {
        public string EmployeeName { get; set; }
    }
}