using Library.CRUD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
