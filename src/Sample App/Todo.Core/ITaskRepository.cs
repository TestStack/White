using System.Collections.Generic;
using System.Threading.Tasks;

namespace Todo.Core
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TodoItem>> GetAll();
        Task Add(TodoItem todoItem);
        Task Delete(int id);
        Task<TodoItem> Get(int id);
    }
}