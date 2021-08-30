using System;

namespace Library.Items
{
    /// <summary>
    /// Class for issued book
    /// </summary>
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

        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="issuedBookId">Issued book id</param>
        /// <param name="readerId">Reader id</param>
        /// <param name="bookId">Book id</param>
        /// <param name="dateOfIssue">Date of issue</param>
        /// <param name="dateOfReturn">The date until which you must return the book</param>
        /// <param name="bookReturn">Book return? (true or false)</param>
        /// <param name="bookCondition">Book condition</param>
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
