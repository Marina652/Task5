using Library;
using Library.Items;
using Library.ProcessesDB;
using Library.ProcessesDB.DAO;
using System;
using System.Data.SqlClient;
using static Library.Items.Book;
using static Library.Items.Reader;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            //IssuedBookDAO issuedBookDAO = new();
            //var t = issuedBookDAO.SelectAll();
            //foreach(var i in t)
            //    Console.WriteLine(i.BookId);

            //ProcessingDataInCollections processing = new();
            //var t = processing.InformationAboutBorrowedBooksForThePeriod(new DateTime(2021, 3, 1), new DateTime(2021, 10, 1));
            //foreach (var i in t)
            //    Console.WriteLine(i.ToString());

            //BookDAO books = new BookDAO();
            //books.Truncate();
            //books.Insert(new Book(1, "Joanne Rowling", "Harry Potter and the philosopher's stone", BookGenre.Fantastic));
            //books.Insert(new Book(2, "Arthur Conan Doyle", "The Hound of the Baskervilles", BookGenre.Detective));
            //books.Insert(new Book(3, "Arthur Conan Doyle", "The Adventures of Sherlock Holmes", BookGenre.Detective));
            //books.Insert(new Book(4, "Isaac Asimov", "The Stars, Like Dust", BookGenre.Fantastic));
            //books.Insert(new Book(5, "Alexander Green", "Scarlet Sails", BookGenre.Romantic));

            //ReadershipDAO subscribers = new();
            //subscribers.Truncate();
            //subscribers.Insert(new Reader(1, "Ivanov", "Ivan", "Ivanovich", ReaderSex.mal, new DateTime(1994, 11, 5)));
            //subscribers.Insert(new Reader(2, "Pechkin", "Alexsandr", "Antonovish", ReaderSex.mal, new DateTime(1986, 6, 2)));
            //subscribers.Insert(new Reader(3, "Ostapova", "Ekaterina", "Alexandrovna", ReaderSex.fem, new DateTime(2001, 11, 12)));
            //subscribers.Insert(new Reader(4, "Petrov", "Victor", "Nikolaevich ", ReaderSex.mal, new DateTime(2002, 4, 26)));
            //subscribers.Insert(new Reader(5, "Morozova", "Victoria", "Victorovna", ReaderSex.fem, new DateTime(1984, 10, 30)));

            //IssuedBookDAO subscriberDetails = new();
            //subscriberDetails.Truncate();
            //subscriberDetails.Insert(new IssuedBook(0, 4, 2, new DateTime(2021, 2, 21), new DateTime(2021, 4, 1), true, 3));
            //subscriberDetails.Insert(new IssuedBook(0, 4, 2, new DateTime(2021, 1, 22), new DateTime(2021, 3, 15), true, 2));
            //subscriberDetails.Insert(new IssuedBook(0, 1, 4, new DateTime(2021, 6, 2), new DateTime(2021, 9, 21), false, 4));
            //subscriberDetails.Insert(new IssuedBook(0, 5, 1, new DateTime(2021, 6, 6), new DateTime(2021, 10, 30), false, 5));
            //subscriberDetails.Insert(new IssuedBook(0, 2, 4, new DateTime(2021, 5, 21), new DateTime(2021, 6, 5), true, 5));
            //subscriberDetails.Insert(new IssuedBook(0, 3, 5, new DateTime(2021, 4, 5), new DateTime(2021, 7, 3), false, 4));
        }
    }
}
