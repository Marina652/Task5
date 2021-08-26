using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CRUD
{
    public sealed class SingletonDatabase : ISingletonDatabase
    {
        private static readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyLibrary;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private readonly SqlConnection Connection = new(connectionString);
        private static readonly Lazy<SingletonDatabase> instance = new(() => new SingletonDatabase());
        private SingletonDatabase()
        {
            Connection.Open();
        }

        public static SingletonDatabase GetInstance => instance.Value;

        public SqlConnection GetConnection()
        {
            return Connection;
        }

        public void CloseConnection()
        {
            Connection.Close();
        }
    }
}
