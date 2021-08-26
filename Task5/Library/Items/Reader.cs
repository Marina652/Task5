using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Items
{
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

        public enum ReaderSex
        {
            /// <summary>
            /// male view
            /// </summary>
            male = 1,
            /// <summary>
            /// female view
            /// </summary>
            female
        }
    }
}
