namespace RolePlay.Common.System.Data
{
    /// <summary>
    /// Shared data storage with basic adding, modifying, updating, and retrieving functions
    /// </summary>
    /// <typeparam name="TObject">Stored object type</typeparam>
    /// <typeparam name="TKey">Primary key type</typeparam>
    public interface ICommonRepository<TKey, TObject>
    {
        /// <summary>
        /// Get object by key
        /// </summary>
        /// <param name="id">Object id</param>
        /// <returns>Object received by identifier or <see langword="null"/>, if the object is not found</returns>
        public TObject GetById(TKey id);
        /// <summary>
        /// Add a new object to storage
        /// </summary>
        /// <param name="obj">Object to add</param>
        public void Insert(TObject obj);
        /// <summary>
        /// Update object in storage
        /// </summary>
        /// <param name="obj">Object to update</param>
        public void Update(TObject obj);
        /// <summary>
        /// Delete object from storage
        /// </summary>
        /// <param name="id">Object ID</param>
        public void Delete(TKey id);
    }
}
