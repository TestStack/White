namespace White.Core.UIItems.ListBoxItems
{
    public interface ListItemContainer
    {
        ListItem Item(string itemText);
        ListItem Item(int index);
        void Select(string itemText);
        void Select(int index);
        string SelectedItemText { get; }
        ListItem SelectedItem { get; }
    }
}