using Library.Items;
using Library.ProcessesDB.DAO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    /// <summary>
    /// Class for processing data with collection
    /// </summary>
    public class ProcessingDataInCollections
    {
        /// <summary>
        /// Object DAO book
        /// </summary>
        private readonly BookDAO books = new();

        /// <summary>
        /// Object DAO issued book
        /// </summary>
        private readonly IssuedBookDAO issuedBooks = new();

        /// <summary>
        /// Object DAO reader
        /// </summary>
        private readonly ReadershipDAO readership = new();

        /// <summary>
        /// Method for finding the most popular author
        /// </summary>
        /// <returns>string</returns>
        public string TheMostPopulatAuthor()
        {
            var result = (from book in books.SelectAll()
                          from issB in issuedBooks.SelectAll()
                          where book.BookId == issB.BookId
                          group book by book.Author into temp
                          select new
                          {
                              AuthorName = temp.Key,
                              Count = temp.Count()
                          }).OrderBy(i => i.Count).Last().AuthorName;
            return result;
        }

        /// <summary>
        /// Method for finding the most reading subscriber
        /// </summary>
        /// <returns>list of readers</returns>
        public List<Reader> TheMostReadingSubscriber()
        {
            var result = (from readership in readership.SelectAll()
                          from issB in issuedBooks.SelectAll()
                          where readership.ReaderId == issB.ReaderId
                          group readership by readership.ReaderId into temp
                          select new
                          {
                              ReaderId = temp.Key,
                              Count = temp.Count()
                          }).OrderBy(i => i.Count).Last().ReaderId;

            return readership.SelectAll().Where(i => i.ReaderId == result).ToList();
        }

        /// <summary>
        /// Method for find the most popular genre
        /// </summary>
        /// <returns>string</returns>
        public string TheMostPopulatGenre()
        {
            var result = (from book in books.SelectAll()
                          from issB in issuedBooks.SelectAll()
                          where book.BookId == issB.BookId
                          group book by book.Genre into temp
                          select new
                          {
                              Genre = temp.Key,
                              Count = temp.Count()
                          }).OrderBy(i => i.Count).Last().Genre.ToString();
            return result;
        }

        /// <summary>
        /// Method for find books requiring restiration
        /// </summary>
        /// <returns>list of books</returns>
        public List<Book> BooksRequiringRestoration()
        {
            var result = (from book in books.SelectAll()
                          from issB in issuedBooks.SelectAll()
                          where book.BookId == issB.BookId && issB.BookCondition <= 3
                          select book).Distinct().ToList();
            return result;
        }

        /// <summary>
        /// information about how many times have each book been taken
        /// </summary>
        /// <returns>list of string</returns>
        public List<string> CountOfBooks()
        {
            var res = (from book in books.SelectAll()
                       from issB in issuedBooks.SelectAll()
                       where book.BookId == issB.BookId
                       group book by book.BookName into temp
                       select new
                       {
                           Name = temp.Key,
                           Count = temp.Count()
                       }).ToList();
            List<string> list = new();
            foreach (var i in res)
                list.Add(i.Name + "; " + i.Count);
            return list;
        }

        /// <summary>
        /// Information about borrowed books for the period
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>list of string</returns>
        public List<string> InformationAboutBorrowedBooksForThePeriod(DateTime startDate, DateTime endDate)
        {
            var res = (from book in books.SelectAll()
                       from issB in issuedBooks.SelectAll()
                       from r in readership.SelectAll()
                       where r.ReaderId == issB.ReaderId && issB.DateOfIssue >= startDate
                       && issB.DateOfReturn <= endDate && book.BookId == issB.BookId
                       select new
                       {
                           ReaderName = r.FirstName,
                           ReaderSurname = r.Surname,
                           Book = book.BookName,
                           BookGenre = book.Genre,
                           DateStart = issB.DateOfIssue,
                           DateEnd = issB.DateOfReturn
                       }).ToList();

            List<string> list = new();
            foreach(var i in res)
                list.Add(i.ReaderName + " " + i.ReaderSurname + "; " + i.Book + "; " + i.DateStart + "; " + i.DateEnd + ";");
            return list;
        }
    }
}
  