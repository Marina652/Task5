namespace Library.ProcessesDB.DAO
{
    /// <summary>
    /// Interface for DAO
    /// </summary>
    /// <typeparam name="T">generic type</typeparam>
    public interface IDAO<T>
    {
        /// <summary>
        /// Method for insert data
        /// </summary>
        /// <param name="obj">generic type</param>
        void Insert(T obj);

        /// <summary>
        /// Method for delete data
        /// </summary>
        /// <param name="obj">generic type</param>
        public void Delete(T obj);

        /// <summary>
        /// Method for update data
        /// </summary>
        /// <param name="obj">generic type</param>
        public void Update(T obj);
    }
}
