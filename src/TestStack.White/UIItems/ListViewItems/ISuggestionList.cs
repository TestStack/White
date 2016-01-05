using System.Collections.Generic;

namespace TestStack.White.UIItems.ListViewItems
{
    public interface ISuggestionList
    {
        List<string> Items { get; }
        void Select(string text);
    }
}