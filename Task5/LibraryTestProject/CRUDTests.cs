using Library.Items;
using Library.ProcessesDB.DAO;
using NUnit.Framework;
using System;

namespace LibraryTestProject
{
    /// <summary>
    /// Class for testing CRUD
    /// </summary>
    [TestFixture]
    public class CRUDTests
    {
        /// <summary>
        /// Testing CRUD for book
        /// </summary>
        [Test]
        public void CRUDBookTest()
        {
            BookDAO bookDAO = new();
            Book book = new(0, "Author", "Name", Book.BookGenre.Detective);
            var count = bookDAO.SelectAll().Count;
            bookDAO.Insert(book);
            var res1 = bookDAO.SelectAll()[bookDAO.SelectAll().Count - 1];
            Assert.AreEqual(res1.BookName, book.BookName);

            res1.BookName = "Name2";
            bookDAO.Update(res1);
            var res2 = bookDAO.SelectAll()[bookDAO.SelectAll().Count - 1];
            Assert.AreEqual(res1, res2);

            bookDAO.Delete(res2.BookId);
            Assert.AreEqual(bookDAO.SelectAll().Count, count);
        }

        /// <summary>
        /// Testing CRUD for issued book
        /// </summary>
        [Test]
        public void CRUDIssuedBookTest()
        {
            IssuedBookDAO issuedBookDAO = new();
            IssuedBook issuedBook1 = new(2, 2, 4, new DateTime(2020, 2, 12), new DateTime(2021, 1, 1), true, 4);
            var count = issuedBookDAO.SelectAll().Count;
            issuedBookDAO.Insert(issuedBook1);
            var res1 = issuedBookDAO.SelectAll()[issuedBookDAO.SelectAll().Count - 1];
            Assert.AreEqual(res1.BookId, issuedBook1.BookId);

            res1.BookCondition = 3;
            issuedBookDAO.Update(res1);
            var res2 = issuedBookDAO.SelectAll()[issuedBookDAO.SelectAll().Count - 1];
            Assert.AreEqual(res1, res2);

            issuedBookDAO.Delete(res2.IssuedBookId);
            Assert.AreEqual(issuedBookDAO.SelectAll().Count, count);
        }

        /// <summary>
        /// Testing CRUD for reader
        /// </summary>
        [Test]
        public void CRUDReaderTest()
        {
            ReadershipDAO readerDAO = new();
            Reader reader1 = new(1, "Surname", "FirstName", "MiddleName", Reader.ReaderSex.fem, new DateTime(2000, 12, 12));
            var count = readerDAO.SelectAll().Count;
            readerDAO.Insert(reader1);
            var res1 = readerDAO.SelectAll()[readerDAO.SelectAll().Count - 1];
            Assert.AreEqual(res1.Surname, reader1.Surname);

            res1.Surname = "Surname1";
            readerDAO.Update(res1);
            var res2 = readerDAO.SelectAll()[readerDAO.SelectAll().Count - 1];
            Assert.AreEqual(res1, res2);

            readerDAO.Delete(res2.ReaderId);
            Assert.AreEqual(readerDAO.SelectAll().Count, count);
        }
    }
}
