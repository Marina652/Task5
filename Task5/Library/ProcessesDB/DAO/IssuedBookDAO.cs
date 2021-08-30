using Library.Items;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Library.ProcessesDB.DAO
{
    /// <summary>
    /// Class for issued book DAO
    /// </summary>
    public class IssuedBookDAO : DbAccess<IssuedBook>, IDAO<IssuedBook>
    {
        //public void Truncate()
        //{
        //    SqlCommand command = new("TRUNCATE TABLE IssuedBooks", connection);


        //    command.ExecuteNonQuery();
        //    command.Dispose();
        //}

        /// <summary>
        /// Method for insert data about issued book 
        /// </summary>
        /// <param name="obj">Issued book object</param>
        public void Insert(IssuedBook obj)
        {
            SqlCommand command = new("Insert Into IssuedBooks" +
                             "(ReaderId, BookId, DateOfIssue, DateOfReturn, BookReturn, BookCondition) " +
                             "Values(@ReaderId, @BookId, @DateOfIssue, @DateOfReturn, @BookReturn, @BookCondition)", connection);

            command.Parameters.AddWithValue("@ReaderId", obj.ReaderId);
            command.Parameters.AddWithValue("@BookId", obj.BookId);
            command.Parameters.AddWithValue("@DateOfIssue", obj.DateOfIssue);
            command.Parameters.AddWithValue("@DateOfReturn", obj.DateOfReturn);
            command.Parameters.AddWithValue("@BookReturn", obj.BookReturn);
            command.Parameters.AddWithValue("@BookCondition", obj.BookCondition);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        /// <summary>
        /// Method for update data about issued book 
        /// </summary>
        /// <param name="obj">Issued book object</param>
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

        /// <summary>
        /// Method for delete data about issued book 
        /// </summary>
        /// <param name="obj">Issued book object</param>
        public void Delete(IssuedBook obj)
        {
            SqlCommand command = new("Delete from IssuedBooks where IssuedBookId = @IssuedBookId", connection);

            command.Parameters.AddWithValue("@IssuedBookId", obj.IssuedBookId);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        /// <summary>
        /// Method for delete data about issued book 
        /// </summary>
        /// <returns>list of issued book</returns>
        public List<IssuedBook> SelectAll()
        {
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
                }
            }
            reader.Close();
            return list;
        }
    }
}
