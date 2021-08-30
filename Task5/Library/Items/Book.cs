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

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Book() { }

        /// <summary>
        /// Override method ToString()
        /// </summary>
        /// <returns>string</returns>
        public override string ToString() => BookName + ", " + Author;

        /// <summary>
        /// Override method GetHashCode()
        /// </summary>
        /// <returns>hash-code</returns>
        public override int GetHashCode() => BookId;
        
        /// <summary>
        /// Override method Equals()
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>true or false</returns>
        public override bool Equals(object obj) => obj is Book book &&
                 BookId == book.BookId &&
                 Author == book.Author &&
                 BookName == book.BookName &&
                 Genre == book.Genre;

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
