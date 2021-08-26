using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Items
{
    public class Book
    {
        /// <summary>
        /// Book Id
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Book author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Book name
        /// </summary>
        public string BookName { get; set; }

        /// <summary>
        /// Book genre
        /// </summary>
        public BookGenre Genre { get; set; }

        public Book(int bookId, string author, string bookName, BookGenre genre)
        {
            BookId = bookId;
            Author = author;
            BookName = bookName;
            Genre = genre;
        }

        public enum BookGenre
        {
            Detective,
            Fantastic,
            Romantic
        }
    }
}
