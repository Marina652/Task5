using Library.Items;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using static Library.Items.Book;

namespace Library.ProcessesDB.DAO
{
    /// <summary>
    /// Class for book DAO
    /// </summary>
    public class BookDAO : DbAccess<Book>, IDAO<Book>
    {
        //public void Truncate()
        //{
        //    SqlCommand command = new("TRUNCATE TABLE Books", connection);
            

        //    command.ExecuteNonQuery();
        //    command.Dispose();
        //}

        /// <summary>
        /// Method for insert data about book 
        /// </summary>
        /// <param name="obj">Book object</param>
        public void Insert(Book obj)
        {
            SqlCommand command = new("Insert Into Books" +
                             "(Author, BookName, Genre) Values(@Author,@BookName,@Genre)", connection);
            command.Parameters.AddWithValue("@Author", obj.Author);
            command.Parameters.AddWithValue("@BookName", obj.BookName);
            command.Parameters.AddWithValue("@Genre", obj.Genre);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        /// <summary>
        /// Method for update data about book 
        /// </summary>
        /// <param name="obj">Book object</param>
        public void Update(Book obj)
        {
            SqlCommand command = new("Update Books Set Author = @Author,  BookName = @BookName, Genre = @Genre Where BookId = @BookId", connection);

            command.Parameters.AddWithValue("@BookId", obj.BookId);
            command.Parameters.AddWithValue("@Author", obj.Author);
            command.Parameters.AddWithValue("@BookName", obj.BookName);
            command.Parameters.AddWithValue("@Genre", obj.Genre);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        /// <summary>
        /// Method for delete data about book 
        /// </summary>
        /// <param name="obj">Book object</param>
        public void Delete(Book obj)
        {
            SqlCommand command = new("Delete from Books where BookId = @BookId", connection);

            command.Parameters.AddWithValue("@BookId", obj.BookId);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        /// <summary>
        /// Method for select data about book 
        /// </summary>
        /// <returns>list of books</returns>
        public List<Book> SelectAll()
        {
            //creator.list.Clear();
            List<Book> list = new();
            SqlCommand command = new($"SELECT * FROM Books", connection);
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add(createFactory.Creator(Convert.ToInt32(reader["BookId"]),
                        reader["Author"].ToString(), reader["BookName"].ToString(),
                        ParseEnum<BookGenre>(reader["Genre"].ToString())));
                }
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// Method for parsing enum
        /// </summary>
        /// <typeparam name="T">generic type</typeparam>
        /// <param name="value">string</param>
        /// <returns>generic type</returns>
        private static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
