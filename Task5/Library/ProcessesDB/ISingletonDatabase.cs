using System.Data.SqlClient;

namespace Library.CRUD
{
    /// <summary>
    /// Singleton interface
    /// </summary>
    public interface ISingletonDatabase
    {
        /// <summary>
        /// Method for close connection Db
        /// </summary>
        void CloseConnection();

        /// <summary>
        /// Method for get connection DB
        /// </summary>
        /// <returns>Sql connection</returns>
        SqlConnection GetConnection();

        /// <summary>
        /// Method for get instance
        /// </summary>
        static SingletonDatabase GetInstance { get; }
    }
}