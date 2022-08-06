using System;

namespace RolePlay.Common.System.Exceptions
{
    /// <summary>
    /// Exception thrown when data requested by ID is not found
    /// </summary>
    public class DataNotFoundException : Exception
    {
        /// <summary>
        /// Throw a new exception that no data was found
        /// </summary>
        /// <param name="id">ID from the request</param>
        public DataNotFoundException(object id) : base($"No data found for id {id}")
        { }
    }
}
