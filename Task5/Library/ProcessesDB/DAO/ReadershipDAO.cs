using Library.Items;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Library.Items.Reader;

namespace Library.ProcessesDB.DAO
{
    public class ReadershipDAO : DbAccess<Reader>, IDAO<Reader>
    {
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

        public void Delete(Reader obj)
        {
            SqlCommand command = new("Delete from Readership where ReaderId = @ReaderId", connection);

            command.Parameters.AddWithValue("@ReaderId", obj.ReaderId);

            command.ExecuteNonQuery();
            command.Dispose();
        }

        public List<Reader> SelectAll()
        {
            //creator.list.Clear();
            List<Reader> list = new();
            SqlCommand command = new($"SELECT * FROM Readership", connection);
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add(createFactory.Creator(Convert.ToInt32(reader["ReaderId"]), reader["Surname"].ToString(), reader["FirstName"].ToString(), reader["MiddleName"].ToString(), ParseEnum<ReaderSex>(reader["Sex"].ToString()), Convert.ToDateTime(reader["DateOfBirth"])));
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
