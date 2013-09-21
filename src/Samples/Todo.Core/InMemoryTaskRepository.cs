using System.Collections.Generic;
using System.Threading.Tasks;

namespace Todo.Core
{
    /// <summary>
    /// In memory repository where all operations take at least 1 second
    /// </summary>
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly Dictionary<int, TodoItem> tasks = new Dictionary<int, TodoItem>();
        private int currentId;

        public Task<IEnumerable<TodoItem>> GetAll()
        {
            return TaskEx.Delay(1500)
            .ContinueWith<IEnumerable<TodoItem>>(t => tasks.Values);
        }

        public Task Add(TodoItem todoItem)
        {
            return TaskEx.Delay(1500)
                .ContinueWith(t => tasks.Add(currentId++, todoItem));
        }

        public Task Delete(int id)
        {
            return TaskEx.Delay(1500)
                .ContinueWith(t =>
                {
                    if (tasks.ContainsKey(id))
                        tasks.Remove(id);
                });
        }

        public Task<TodoItem> Get(int id)
        {
            return TaskEx.Delay(1500)
                .ContinueWith(t =>
                {
                    if (tasks.ContainsKey(id))
                        return tasks[id];

                    return null;
                });

        }
    }
}