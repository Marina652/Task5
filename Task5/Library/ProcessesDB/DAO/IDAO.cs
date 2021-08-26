using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ProcessesDB.DAO
{
    public interface IDAO<T>
    {
        void Insert(T obj);
        public void Delete(T obj);
        public void Update(T obj);
    }
}
