namespace WpfTestApplication
{
    public class ListViewData
    {
        public ListViewData()
        {
        }

        public ListViewData(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}