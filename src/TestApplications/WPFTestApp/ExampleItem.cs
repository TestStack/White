namespace WindowsPresentationFramework
{
    public class ExampleItem
    {
        private readonly int index;
        private readonly string name;

        public ExampleItem(int i, string s)
        {
            index = i;
            name = s;
        }

        public string Name
        {
            get { return name; }
        }

        public int Index
        {
            get { return index; }
        }

        public override string ToString()
        {
            return name;
        }
    }
}