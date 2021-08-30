using Library.CRUD;
using System.Data.SqlClient;

namespace Library.ProcessesDB
{
    /// <summary>
    /// Class for database access
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class DbAccess<T>
    {
        /// <summary>
        /// Get instance
        /// </summary>
        private static readonly SingletonDatabase singleton = SingletonDatabase.GetInstance;

        /// <summary>
        /// Get connection to Db
        /// </summary>
        protected SqlConnection connection = singleton.GetConnection();

        /// <summary>
        /// Object factory method
        /// </summary>
        protected Factory<T> create = new();
    }
}
