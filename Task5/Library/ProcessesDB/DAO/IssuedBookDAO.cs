using Library.Items;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ProcessesDB.DAO
{
    public class IssuedBookDAO : DbAccess<IssuedBook>, IDAO<IssuedBook>
    {
        public void Insert(IssuedBook obj)
        {
            SqlCommand command = new("Insert Into IssuedBooks" +
                             "(ReaderId, BookId, DataOeIssue, DateOfReturn, BookReturn, BookCondition) " +
                             "Values(@ReaderId, @BookId, @DataOeIssue, @DateOfReturn, @BookReturn, @BookCondition)", connection);
            //command.Parameters.AddWithValue("@IssuedBookId", obj.IssuedBookId);
            command.Parameters.AddWithValue("@ReaderId", obj.ReaderId);
            command.Parameters.AddWithValue("@BookId", obj.BookId);
            command.Parameters.AddWithValue("@DateOfIssue", obj.DateOfIssue);
            command.Parameters.AddWithValue("@DateOgReturn", obj.DateOfReturn);
            command.Parameters.AddWithValue("@BookReturn", obj.BookReturn);
            command.Parameters.AddWithValue("@BookCondition", obj.BookCondition);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void Update(IssuedBook obj)
        {
            SqlCommand command = new("Update IssuedBooks Set ReaderId = @ReaderId,  " +
                "BookId = @BookId, DateOfIssue = @DateOfIssue, DateOfReturn = @DateOfReturn, " +
                "BookReturn = @Bookreturn, BookCondition = @BookCondition Where IssuedBookId = @IssuedBookId", connection);

            command.Parameters.AddWithValue("@IssuedBookId", obj.IssuedBookId);
            command.Parameters.AddWithValue("@ReaderId", obj.ReaderId);
            command.Parameters.AddWithValue("@BookId", obj.BookId);
            command.Parameters.AddWithValue("@DateOfIssue", obj.DateOfIssue);
            command.Parameters.AddWithValue("@DateOgReturn", obj.DateOfReturn);
            command.Parameters.AddWithValue("@BookReturn", obj.BookReturn);
            command.Parameters.AddWithValue("@BookCondition", obj.BookCondition);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void Delete(IssuedBook obj)
        {
            SqlCommand command = new("Delete from IssuedBooks where IssuedBookId = @IssuedBookId", connection);

            command.Parameters.AddWithValue("@IssuedBookId", obj.IssuedBookId);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public List<IssuedBook> SelectAll()
        {
            //creator.list.Clear();
            List<IssuedBook> list = new();
            SqlCommand command = new($"SELECT * FROM IssuedBooks", connection);
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add(createFactory.Creator(Convert.ToInt32(reader["IssuedBookId"]), Convert.ToInt32(reader["ReaderId"]), 
                        Convert.ToInt32(reader["BookId"]), Convert.ToDateTime(reader["DateOfIssue"]), Convert.ToDateTime(reader["DateOfReturn"]), 
                        Convert.ToBoolean(reader["BookReturn"]), Convert.ToInt32(reader["BookCondition"])));
                    //creator.FactoryCreate(Convert.ToInt32(r["BookId"]), r["Author"].ToString(), r["BookName"].ToString(), ParseEnum<BookGenre>(r["Genre"].ToString()));
                }
            }
            reader.Close();
            return list;
        }

        //private static T ParseEnum<T>(string value)
        //{
        //    return (T)Enum.Parse(typeof(T), value, true);
        //}
    }
}
