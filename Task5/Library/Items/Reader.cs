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
