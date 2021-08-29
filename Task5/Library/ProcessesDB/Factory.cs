using System;

namespace Library.ProcessesDB
{
    /// <summary>
    /// Class for realiaze Factory method
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Factory<T>  
    {
        /// <summary>
        ///  Method to create object
        /// </summary>
        /// <param name="objs">Object</param>
        /// <returns>generic type</returns>
        public T Creator(params object []objs)
        {
            return (T)Activator.CreateInstance(typeof(T), objs);
        }
    }
}
