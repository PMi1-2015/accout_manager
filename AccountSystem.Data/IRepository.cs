﻿using System.Collections.Generic;

namespace AccountSystem.Data
{
    /// <summary>
    /// Abstraction for base crud manipulations
    /// </summary>
    /// <typeparam name="E">entity type</typeparam>
    /// <typeparam name="K">key type</typeparam>
    public interface IRepository<E>
    {
        /// <summary>
        /// Get all elements of type T
        /// </summary>
        /// <returns>All elements</returns>
        IEnumerable<E> GetAll();

        /// <summary>
        /// Get element by key
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>element</returns>
        E GetByKey(object key);

        /// <summary>
        /// Adding new entity
        /// </summary>
        /// <param name="entity">new entity</param>
        void Add(E entity);
        
        /// <summary>
        /// Removes entity by key
        /// </summary>
        /// <param name="id">id of entity to delete</param>
        void Delete(object key);

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="entity">entity to update</param>
        void Update(E entity);
    }
}
