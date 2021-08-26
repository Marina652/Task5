using System.Data.SqlClient;

namespace Library.CRUD
{
    public interface ISingletonDatabase
    {
        void CloseConnection();
        SqlConnection GetConnection();
        static SingletonDatabase GetInstance { get; }
    }
}