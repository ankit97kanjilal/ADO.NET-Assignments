using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOKSTOREApp
{
    interface IDataInterface
    {
        List<Book> SelectAllBooks();
        Book SelectBookById(int bookID);
        void InsertBook(Book book);
        void DeleteBook(int bookID);
        void UpdateBookById(Book book);
    }
}
