using System.Windows.Controls;

namespace White.CustomCommands
{
    public class ComboBoxCommands : IComboBoxCommands
    {
        private readonly ComboBox comboBox;

        public ComboBoxCommands(ComboBox comboBox)
        {
            this.comboBox = comboBox;
        }

        public virtual void Select(string itemText)
        {
            foreach (ComboBoxItem comboBoxItem in comboBox.Items)
                if (Equals(comboBoxItem.Content, itemText))
                    comboBox.SelectedItem = comboBoxItem;
        }
    }
}