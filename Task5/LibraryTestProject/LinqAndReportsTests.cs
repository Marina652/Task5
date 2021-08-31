using Library;
using Library.FormationReport;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LibraryTestProject
{
    /// <summary>
    /// Class for testing methods with linq and methods for creating reports
    /// </summary>
    [TestFixture]
    public class LinqAndReportsTests
    {
        /// <summary>
        /// Testing method TheMostPopularAuthors()
        /// </summary>

        [Test]
        public void TheMostPopularAuthorsTest()
        {
            ProcessingDataInCollections processing = new();
            Assert.AreEqual(processing.TheMostPopulatAuthor(), "Arthur Conan Doyle");    
        }

        /// <summary>
        /// Testing method TheMostReadingSubscriber()
        /// </summary>
        [Test]
        public void TheMostReadingSubscriberTest()
        {
            ProcessingDataInCollections processing = new();
            var list = processing.TheMostReadingSubscriber();
            List<string> readersList = new();
            list.ForEach(i => readersList.Add(i.ToString()));
            List<string> myList = new();
            myList.Add("Petrov Victor Nikolaevich  mal 26.04.2002 0:00:00");
            Assert.AreEqual(readersList, myList);
        }

        /// <summary>
        /// Testing method TheMostPopularGenre()
        /// </summary>
        [Test]
        public void TheMostPopularGenreTest()
        {
            ProcessingDataInCollections processing = new();
            Assert.AreEqual(processing.TheMostPopulatGenre(), "Detective");
        }

        /// <summary>
        /// Testing method BooksRequiringRestoration()
        /// </summary>
        [Test]
        public void BooksRequiringRestorationTest()
        {
            ProcessingDataInCollections processing = new();
            var res = processing.BooksRequiringRestoration();
            List<string> list = new();
            res.ForEach(i => list.Add(i.ToString()));
            List<string> myList = new();
            myList.Add("The Hound of the Baskervilles, Arthur Conan Doyle");
            myList.Add("The Adventures of Sherlock Holmes, Arthur Conan Doyle");
            Assert.AreEqual(list, myList);
        }

        /// <summary>
        /// Testing method CountOfBooks()
        /// </summary>
        [Test]
        public void CountOfBooksTest()
        {
            ProcessingDataInCollections processing = new();
            List<string> myList = new();
            myList.Add("Harry Potter and the philosopher's stone; 1");
            myList.Add("The Hound of the Baskervilles; 1");
            myList.Add("The Adventures of Sherlock Holmes; 2");
            myList.Add("The Stars, Like Dust; 1");
            myList.Add("Scarlet Sails; 1");
            Assert.AreEqual(processing.CountOfBooks(), myList);
        }

        /// <summary>
        /// Testing method for find borrowed books for the period
        /// </summary>
        [Test]
        public void InformationAboutBorrowedBooksForThePeriodTest()
        {
            ProcessingDataInCollections processing = new();
            List<string> myList = new();
            myList.Add("Alexsandr Pechkin; The Adventures of Sherlock Holmes; 21.05.2021 0:00:00; 05.06.2021 0:00:00;");
            myList.Add("Ivan Ivanov; The Stars, Like Dust; 02.06.2021 0:00:00; 21.09.2021 0:00:00;");
            myList.Add("Ekaterina Ostapova; Scarlet Sails; 05.04.2021 0:00:00; 03.07.2021 0:00:00;");
            Assert.AreEqual(processing.InformationAboutBorrowedBooksForThePeriod(new DateTime(2021, 3, 1), new DateTime(2021, 10, 1)), myList);
        }

        /// <summary>
        /// Testing method find borrowed books by genre
        /// </summary>
        [Test]
        public void InformationAboutBorrowedBooksByGenre()
        {
            ProcessingDataInCollections processing = new();
            List<string> myList = new();
            myList.Add("Fantastic; 2");
            myList.Add("Detective; 3");
            myList.Add("Romantic; 1");
            Assert.AreEqual(processing.BorrowedBooksByGenre(), myList);
        }

        /// <summary>
        /// Testing method for test created reports
        /// </summary>
        [Test]
        public void CreateReports()
        {
            ProcessingDataInCollections processing = new();
            CreateTxtFile.Report("../../../Reports/ReportTxt.txt", processing.BorrowedBooksByGenre());
            CreateXlsxFile.Report("../../../Reports/ReportXlsx.xlsx", processing.InformationAboutBorrowedBooksForThePeriod(new DateTime(2021, 3, 1), new DateTime(2021, 10, 1)));
            CreatePdfFile.Report("../../../Reports/ReportPdf.pdf", processing.CountOfBooks());
            CreateReports createReports = new();
            createReports.Create();
        }
    }
}