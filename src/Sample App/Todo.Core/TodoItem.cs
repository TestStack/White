using System;

namespace Todo.Core
{
    public class TodoItem : NotifyPropertyChanged
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
