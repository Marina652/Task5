using Library.Items;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Library.Items.Book;

namespace Library.ProcessesDB.DAO
{
    public class BookDAO : DbAccess<Book>, IDAO<Book>
    {
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

        public void Delete(Book obj)
        {
            SqlCommand command = new("Delete from Books where BookId = @BookId", connection);

            command.Parameters.AddWithValue("@BookId", obj.BookId);

            command.ExecuteNonQuery();
            command.Dispose();
        }

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
                    //creator.FactoryCreate(Convert.ToInt32(r["BookId"]), r["Author"].ToString(), r["BookName"].ToString(), ParseEnum<BookGenre>(r["Genre"].ToString()));
                }
            }
            reader.Close();
            return list;
        }

        private static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
