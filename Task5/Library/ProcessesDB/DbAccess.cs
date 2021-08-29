using Library.CRUD;
using System.Data.SqlClient;

namespace Library.ProcessesDB
{
    public abstract class DbAccess<T>
    {
        //private static readonly ISingletonDatabase singleton = ISingletonDatabase.GetInstance;
        private static readonly SingletonDatabase singleton = SingletonDatabase.GetInstance;
        protected SqlConnection connection = singleton.GetConnection();
        protected Factory<T> createFactory = new();
    }
}
