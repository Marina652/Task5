using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ProcessesDB
{
    public class Factory<T>  
    {
        public T Creator(params object []objs)
        {
            return (T)Activator.CreateInstance(typeof(T), objs);
        }
    }
}
