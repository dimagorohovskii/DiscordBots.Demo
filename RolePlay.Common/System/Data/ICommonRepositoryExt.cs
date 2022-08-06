using RolePlay.Common.Game.Contracts.System;
using System.Data;

namespace RolePlay.Common.System.Data
{
    /// <summary>
    /// Shared data storage with basic add, modify, update, and retrieve functions. Extended to work with <see cref="IChangeable"/> objects
    /// </summary>
    /// <typeparam name="TObject">Stored object type</typeparam>
    /// <typeparam name="TKey">Primary key type</typeparam>
    public interface ICommonRepositoryExt<TKey, TObject> : ICommonRepository<TKey, TObject> where TObject : IChangeable
    {
        /// <summary>
        /// Update object and all children, depending on flags <see cref="IChangeable"/>
        /// </summary>
        /// <param name="obj">Object to update</param>
        public void UniversalUpdate(TObject obj);
        /// <summary>
        /// Update object and all children, depending on flags <see cref="IChangeable"/>
        /// </summary>
        /// <param name="obj">Object to update</param>
        /// <param name="transaction">The transaction in which the update occurs</param>
        public void UniversalUpdate(TObject obj, IDbTransaction? transaction);
        /// <summary>
        /// Generate or update a table in storage
        /// </summary>
        public void CreateOrUpdateTable();
    }
}
