namespace Recipe.Domain.Persistence
{
    using Recipe.Domain.Common.Models;

    /// <summary>
    /// Represents a generic repository interface.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    public interface IRepository<T>
        where T : Entity<int>
    {
        /// <summary>
        /// Retrieves all entities asynchronously.
        /// </summary>
        /// <returns>A collection of entities.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Retrieves an entity by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>The retrieved entity, or null if not found.</returns>
        Task<T?> GetByIdAsync(int? id);

        /// <summary>
        /// Inserts an entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        /// <returns>True if the entity was inserted successfully, false otherwise.</returns>
        Task<bool> InsertAsync(T entity);

        /// <summary>
        /// Updates an entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>True if the entity was updated successfully, false otherwise.</returns>
        Task<bool> UpdateAsync(T entity);

        /// <summary>
        /// Deletes an entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        /// <returns>True if the entity was deleted successfully, false otherwise.</returns>
        Task<bool> DeleteAsync(T entity);

        /// <summary>
        /// Retrieves all entities synchronously.
        /// </summary>
        /// <returns>A collection of entities.</returns>
        IEnumerable<T> GetAll();
    }
}
