namespace TestStack.White.Configuration
{
    public interface IUIItemIdConfiguration
    {
        string TableVerticalScrollBar { get; set; }
        string TableHorizontalScrollBar { get; set; }
        string TableColumn { get; set; }
        string TableTopLeftHeaderCell { get; set; }
        string TableCellNullValue { get; set; }
        string TableHeader { get; set; }
        string HorizontalScrollBar { get; set; }
        string VerticalScrollBar { get; set; }
        string TableCellPrefix { get; set; }
        /// <summary>
        /// The text for the "browse"-button
        /// </summary>
        string BrowseText { get; set; }
        /// <summary>
        /// The dialog title of the open browse dialog
        /// </summary>
        string OpenFileDialogTitle { get; set; }
        /// <summary>
        /// Text of the misc category on a property grid
        /// </summary>
        string PropertyGridMiscText { get; set; }
    }
}