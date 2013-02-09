using System.Collections.ObjectModel;

namespace WindowsPresentationFramework
{
    public class ExampleCollection : ObservableCollection<ExampleItem>
    {
        private readonly ObservableCollection<ExampleItem> examples;

        public ExampleCollection()
        {
            examples = new ObservableCollection<ExampleItem>();
        }

        public ObservableCollection<ExampleItem> ExampleItemsCollection
        {
            get { return examples; }
        }
    }
}