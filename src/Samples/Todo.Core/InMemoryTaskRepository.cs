// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InMemoryTaskRepository.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   In memory repository where all operations take at least 1 second
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Todo.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// In memory repository where all operations take at least 1 second
    /// </summary>
    public class InMemoryTaskRepository : ITaskRepository
    {
        /// <summary>
        /// The tasks.
        /// </summary>
        private readonly Dictionary<int, TodoItem> tasks = new Dictionary<int, TodoItem>();

        /// <summary>
        /// The current id.
        /// </summary>
        private int currentId;

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<IEnumerable<TodoItem>> GetAll()
        {
            return TaskEx.Delay(1500)
            .ContinueWith<IEnumerable<TodoItem>>(t => this.tasks.Values);
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="todoItem">
        /// The to-do item.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task Add(TodoItem todoItem)
        {
            return TaskEx.Delay(1500)
                .ContinueWith(t => this.tasks.Add(this.currentId++, todoItem));
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task Delete(int id)
        {
            return TaskEx.Delay(1500)
                .ContinueWith(t =>
                {
                    if (tasks.ContainsKey(id))
                    {
                        this.tasks.Remove(id);
                    }
                });
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<TodoItem> Get(int id)
        {
            return TaskEx.Delay(1500)
                .ContinueWith(t =>
                {
                    if (tasks.ContainsKey(id))
                    {
                        return tasks[id];
                    }

                    return null;
                });
        }
    }
}