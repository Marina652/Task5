using Library.Items;
using Library.ProcessesDB;
using Library.ProcessesDB.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ProcessingDataInCollections
    {
        readonly BookDAO books = new BookDAO();
        readonly IssuedBookDAO issuedBooks = new IssuedBookDAO();
        readonly ReadershipDAO readership = new ReadershipDAO();

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

        public Reader ThemostReadingSubscriber()
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

            return (Reader)readership.SelectAll().Where(i => i.ReaderId == result);
        }
    }
}
  