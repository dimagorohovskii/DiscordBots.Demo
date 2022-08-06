using System;
using System.Data;

namespace RolePlay.Common.System.Data
{
    /// <summary>
    /// Object factory for data warehouse
    /// </summary>
    public interface IDBFactory
    {
        /// <summary>
        /// Generate a command from its text
        /// </summary>
        /// <param name="command">Command text</param>
        /// <returns>Created command</returns>
        IDbCommand FormCommand(string command);
        /// <summary>
        /// Generate a command from its text
        /// </summary>
        /// <param name="command">Command text</param>
        /// <param name="transaction">The transaction within which the command will be executed</param>
        /// <returns>Created command</returns>
        IDbCommand FormCommand(string command, IDbTransaction transaction);
        /// <summary>
        /// Generate command parameter
        /// </summary>
        /// <param name="name">Parameter name</param>
        /// <param name="value">Parameter value</param>
        /// <returns>Generated parameter</returns>
        IDbDataParameter FormParameter(string name, object value);
        /// <summary>
        /// Generate a transaction
        /// </summary>
        /// <returns>Generated transaction</returns>
        IDbTransaction BeginTransaction();
        /// <summary>
        /// Get the id of the last row of a table
        /// </summary>
        /// <param name="dbTableName">Table name</param>
        /// <returns>Row ID, if any</returns>
        T GetLastRowId<T>(string dbTableName);
        /// <summary>
        /// Get the id of the last row of a table
        /// </summary>
        /// <param name="dbTableName">Table name</param>
        /// <param name="transaction">Command transaction</param>
        /// <returns>Row ID, if any</returns>
        T GetLastRowId<T>(string dbTableName, IDbTransaction transaction);
        /// <summary>
        /// Get string representation of DB type
        /// </summary>
        /// <param name="type">Source type</param>
        /// <returns>DB-type</returns>
        string GetDBType(Type type);
    }
}
