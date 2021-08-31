using Library.Items;
using NUnit.Framework;
using System;

namespace LibraryTestProject
{
    /// <summary>
    /// Class for testing overriden mrthods
    /// </summary>
    [TestFixture]
    public class OverrideMethodsTests
    {
        /// <summary>
        /// Test override method Equals() for book
        /// </summary>
        [Test]
        public void BookEqualsTest()
        {
            Book book1 = new(2, "Author", "Name", Book.BookGenre.Detective);
            Book book2 = new(2, "Author", "Name", Book.BookGenre.Detective);
            Book book3 = new(4, "Author3", "Name3", Book.BookGenre.Detective);
            Assert.IsTrue(book1.Equals(book2));
            Assert.IsFalse(book1.Equals(book3));
            Assert.IsTrue(book1.Equals(book1));
        }

        /// <summary>
        /// Test override method Equals() for issued book
        /// </summary>
        [Test]
        public void IssuedBookEqualsTest()
        {
            IssuedBook issuedBook1 = new(2, 2, 4, new DateTime(2020, 2, 12), new DateTime(2021, 1, 1), true, 4);
            IssuedBook issuedBook2 = new(2, 2, 4, new DateTime(2020, 2, 12), new DateTime(2021, 1, 1), true, 4);
            IssuedBook issuedBook3 = new(4, 1, 6, new DateTime(2020, 2, 12), new DateTime(2021, 1, 1), true, 4);
            Assert.IsTrue(issuedBook1.Equals(issuedBook2));
            Assert.IsFalse(issuedBook1.Equals(issuedBook3));
            Assert.IsTrue(issuedBook1.Equals(issuedBook1));
        }

        /// <summary>
        /// Test override method Equals() for reader
        /// </summary>
        [Test]
        public void ReaderEqualsTest()
        {
            Reader reader1 = new(1, "Surname", "FirstName", "MiddleName", Reader.ReaderSex.fem, new DateTime(2000, 12, 12));
            Reader reader2 = new(1, "Surname", "FirstName", "MiddleName", Reader.ReaderSex.fem, new DateTime(2000, 12, 12));
            Reader reader3 = new(2, "Surname3", "FirstName3", "MiddleName", Reader.ReaderSex.fem, new DateTime(2000, 12, 12));
            Assert.IsTrue(reader1.Equals(reader2));
            Assert.IsFalse(reader1.Equals(reader3));
            Assert.IsTrue(reader1.Equals(reader1));
        }

        /// <summary>
        /// Test methods GetHashCode()
        /// </summary>
        [Test]
        public void TestMethodsGetHashCode()
        {
            Book book1 = new(2, "Author", "Name", Book.BookGenre.Detective);
            IssuedBook issuedBook1 = new(3, 2, 4, new DateTime(2020, 2, 12), new DateTime(2021, 1, 1), true, 4);
            Reader reader1 = new(1, "Surname", "FirstName", "MiddleName", Reader.ReaderSex.fem, new DateTime(2000, 12, 12));
            Assert.AreEqual(book1.GetHashCode(), 2);
            Assert.AreEqual(issuedBook1.GetHashCode(), 3);
            Assert.AreEqual(reader1.GetHashCode(), 1);
        }

        /// <summary>
        /// Test methods ToString()
        /// </summary>
        [Test]
        public void TestMethodsToString()
        {
            Book book1 = new(2, "Author", "Name", Book.BookGenre.Detective);
            IssuedBook issuedBook1 = new(3, 2, 4, new DateTime(2020, 2, 12), new DateTime(2021, 1, 1), true, 4);
            Reader reader1 = new(1, "Surname", "FirstName", "MiddleName", Reader.ReaderSex.fem, new DateTime(2000, 12, 12));
            Assert.AreEqual(book1.ToString(), "Name, Author");
            Assert.AreEqual(issuedBook1.ToString(), "Library.Items.IssuedBook");
            Assert.AreEqual(reader1.ToString(), "Surname FirstName MiddleName fem 12.12.2000 0:00:00");
        }
    }
}
