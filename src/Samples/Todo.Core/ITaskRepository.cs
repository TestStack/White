// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITaskRepository.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the ITaskRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Todo.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The TaskRepository interface.
    /// </summary>
    public interface ITaskRepository
    {
        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IEnumerable<TodoItem>> GetAll();

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="todoItem">
        /// The to-do item.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task Add(TodoItem todoItem);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task Delete(int id);

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TodoItem> Get(int id);
    }
}