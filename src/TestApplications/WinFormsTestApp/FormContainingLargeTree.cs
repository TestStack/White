using System.Windows.Forms;

namespace WinFormsTestApp
{
    public partial class FormContainingLargeTree : Form
    {
        public FormContainingLargeTree()
        {
            InitializeComponent();
            TreeNode treeNode = treeView1.Nodes.Add("Root");
            for (int i = 0; i < 50; i++)
            {
                AddChild(treeNode, string.Format("Child{0}", i));                
            }
        }

        private void AddChild(TreeNode treeNode, string text)
        {
            treeNode.Nodes.Add(text);
        }
    }
}