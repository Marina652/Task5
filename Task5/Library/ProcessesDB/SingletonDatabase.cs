using System;
using System.Data.SqlClient;

namespace Library.CRUD
{
    public sealed class SingletonDatabase : ISingletonDatabase
    {
        /// <summary>
        /// Connection string
        /// </summary>
        private static readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyLibrary;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        /// <summary>
        /// Connection
        /// </summary>
        private readonly SqlConnection Connection = new(connectionString);
        
        /// <summary>
        /// Instance
        /// </summary>
        private static readonly Lazy<SingletonDatabase> instance = new(() => new SingletonDatabase());
       
        /// <summary>
        /// Connection open
        /// </summary>
        private SingletonDatabase()
        {
            Connection.Open();
        }

        /// <summary>
        /// Get instance
        /// </summary>
        public static SingletonDatabase GetInstance => instance.Value;

        /// <summary>
        /// Get Db connection
        /// </summary>
        /// <returns>connection Db</returns>

        public SqlConnection GetConnection()
        {
            return Connection;
        }

        /// <summary>
        /// Close Db connection
        /// </summary>
        public void CloseConnection()
        {
            Connection.Close();
        }
    }
}
