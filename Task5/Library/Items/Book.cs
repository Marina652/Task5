namespace Library.Items
{
    /// <summary>
    /// Class for book
    /// </summary>
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

        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="bookId">Book Id</param>
        /// <param name="author">Authors name</param>
        /// <param name="bookName">Book name</param>
        /// <param name="genre">Genre of book</param>
        public Book(int bookId, string author, string bookName, BookGenre genre)
        {
            BookId = bookId;
            Author = author;
            BookName = bookName;
            Genre = genre;
        }

        public override string ToString() => BookName + ", " + Author;

        /// <summary>
        /// Inner enum for book genre
        /// </summary>
        public enum BookGenre
        {
            /// <summary>
            /// Detective
            /// </summary>
            Detective,
            /// <summary>
            /// Fantastic
            /// </summary>
            Fantastic,
            /// <summary>
            /// Romantic
            /// </summary>
            Romantic
        }
    }
}
