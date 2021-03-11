using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp2
{
    interface IDataDisconnected
    {
        List<Book> SelectAllBooks();
        Book SelectBookByBookCode(string bookCode);
        void InsertBook(Book book);
        void DeleteBook(string bookCode);
        void UpdateBookByBookCode(Book book);
        List<Book> SelectBookByBookName(string bookName);
    }
}
