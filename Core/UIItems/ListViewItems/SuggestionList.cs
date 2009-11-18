using System.Collections.Generic;

namespace White.Core.UIItems.ListViewItems
{
    public interface SuggestionList
    {
        List<string> Items { get; }
        void Select(string text);
    }
}