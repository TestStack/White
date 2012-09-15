using System.Windows.Controls;

namespace White.CustomCommands
{
    public class ListBoxCommands : IListBoxCommands
    {
        private readonly ListBox listBox;

        public ListBoxCommands(ListBox listBox)
        {
            this.listBox = listBox;
        }

        public virtual int ItemCount
        {
            get { return listBox.Items.Count; }
        }
    }
}