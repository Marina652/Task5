using Library.Items;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using static Library.Items.Reader;

namespace Library.ProcessesDB.DAO
{
    /// <summary>
    /// Class for reader DAO
    /// </summary>
    public class ReadershipDAO : DbAccess<Reader>, IDAO<Reader>
    {
        /// <summary>
        /// Method for insert data about reader 
        /// </summary>
        /// <param name="obj">Reader object</param>
        public void Insert(Reader obj)
        {
            SqlCommand command = new("Insert Into Readership" +
                             "(Surname, FirstName, MiddleName, Sex, DateOfBirth) Values(@Surname,@FirstName,@MiddleName,@Sex,@DateOfBirth)", connection);
            command.Parameters.AddWithValue("@Surname", obj.Surname);
            command.Parameters.AddWithValue("@FirstName", obj.FirstName);
            command.Parameters.AddWithValue("@MiddleName", obj.MiddleName);
            command.Parameters.AddWithValue("@Sex", obj.Sex);
            command.Parameters.AddWithValue("@DateOfBirth", obj.DateOfBirth);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        /// <summary>
        /// Method for update data about reader 
        /// </summary>
        /// <param name="obj">Reader object</param>
        public void Update(Reader obj)
        {
            SqlCommand command = new SqlCommand("Update Readership Set Surname = @Surname,  FirstName = @FirstName, MiddleName = @MiddleName, Sex = @Sex, DateOfBirth = @DateOfBirth  Where ReaderId = @ReaderId", connection);

            command.Parameters.AddWithValue("@ReaderId", obj.ReaderId);
            command.Parameters.AddWithValue("@Surname", obj.Surname);
            command.Parameters.AddWithValue("@FirstName", obj.FirstName);
            command.Parameters.AddWithValue("@MiddleName", obj.MiddleName);
            command.Parameters.AddWithValue("@Sex", obj.Sex);
            command.Parameters.AddWithValue("@DateOfBirth", obj.DateOfBirth);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        /// <summary>
        /// Method for delete data about reader 
        /// </summary>
        /// <param name="obj">Reader object</param>
        public void Delete(Reader obj)
        {
            SqlCommand command = new("Delete from Readership where ReaderId = @ReaderId", connection);

            command.Parameters.AddWithValue("@ReaderId", obj.ReaderId);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        /// <summary>
        /// Method for select data about reader
        /// </summary>
        /// <returns>list of reader</returns>
        public List<Reader> SelectAll()
        {
            List<Reader> list = new();
            SqlCommand command = new($"SELECT * FROM Readership", connection);
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add(createFactory.Creator(Convert.ToInt32(reader["ReaderId"]), reader["Surname"].ToString(), 
                        reader["FirstName"].ToString(), reader["MiddleName"].ToString(), 
                        ParseEnum<ReaderSex>(reader["Sex"].ToString()), Convert.ToDateTime(reader["DateOfBirth"])));
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
