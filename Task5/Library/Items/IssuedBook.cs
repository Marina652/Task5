using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Items
{
    public class IssuedBook
    {
        /// <summary>
        /// Issued book id
        /// </summary>
        public int IssuedBookId { get; set; }
        /// <summary>
        /// Reader id
        /// </summary>
        public int ReaderId { get; set; }

        /// <summary>
        /// Book id
        /// </summary>
        public int BookId { get; set; }
        /// <summary>
        /// Date of issue book
        /// </summary>
        public DateTime DateOfIssue { get; set; }

        /// <summary>
        /// Date of return book
        /// </summary>
        public DateTime DateOfReturn { get; set; }

        /// <summary>
        /// book return(true or false)
        /// </summary>
        public bool BookReturn { get; set; }

        /// <summary>
        /// Book condition
        /// </summary>
        public int BookCondition { get; set; }

        public IssuedBook(int issuedBookId, int readerId, int bookId, DateTime dateOfIssue, DateTime dateOfReturn, bool bookReturn, int bookCondition)
        {
            IssuedBookId = issuedBookId;
            ReaderId = readerId;
            BookId = bookId;
            DateOfIssue = dateOfIssue;
            DateOfReturn = dateOfReturn;
            BookReturn = bookReturn;
            BookCondition = bookCondition;
        }
    }
}
