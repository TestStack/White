namespace WindowsPresentationFramework
{
    public class ListViewData
    {
        public ListViewData()
        {
        }

        public ListViewData(string key, string value, string image)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}