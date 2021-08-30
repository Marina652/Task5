using System;

namespace Library.Items
{
    /// <summary>
    /// Class for reader
    /// </summary>
    public class Reader
    {
        /// <summary>
        /// Reader Id
        /// </summary>
        public int ReaderId { get; set; }

        /// <summary>
        /// Reader surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Reader first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Reader middle name
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Reader sex
        /// </summary>
        public ReaderSex Sex { get; set; }

        /// <summary>
        /// Reader date of birth
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="readerId">Reader id</param>
        /// <param name="surname">Reader surname</param>
        /// <param name="firstName">Reader first name</param>
        /// <param name="middleName">Reader middle name</param>
        /// <param name="sex">Reader sex</param>
        /// <param name="dateOfBirth">Reader date of birth</param>
        public Reader(int readerId, string surname, string firstName, string middleName, ReaderSex sex, DateTime dateOfBirth)
        {
            ReaderId = readerId;
            Surname = surname;
            FirstName = firstName;
            MiddleName = middleName;
            Sex = sex;
            DateOfBirth = dateOfBirth;
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Reader() { }

        /// <summary>
        /// Override method ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Surname + " " + FirstName + " " + 
            MiddleName + " " + Sex + " " + DateOfBirth;

        /// <summary>
        /// Override method GetHashCode()
        /// </summary>
        /// <returns>hash-code</returns>
        public override int GetHashCode() => ReaderId;

        /// <summary>
        /// Override method Equals()
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>true or false</returns>
        public override bool Equals(object obj) => obj is Reader reader &&
                 ReaderId == reader.ReaderId &&
                 Surname == reader.Surname &&
                 FirstName == reader.FirstName &&
                 MiddleName == reader.MiddleName &&
                 Sex == reader.Sex &&
                 DateOfBirth == reader.DateOfBirth;

        /// <summary>
        /// Inner enum for reader sex
        /// </summary>
        public enum ReaderSex
        {
            /// <summary>
            /// male view
            /// </summary>
            mal,
            /// <summary>
            /// female view
            /// </summary>
            fem
        }
    }
}
