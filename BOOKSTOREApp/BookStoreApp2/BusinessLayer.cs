using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp2
{
    class BusinessLayer
    {
        public void AddBook(Book book)
        {
            //adding books into the database
            AdoDisconnected dal = new AdoDisconnected();
            dal.InsertBook(book);
        }
        public void DeleteBook(string bookCode)
        {
            //calling delete book using dal layer
            AdoDisconnected dal = new AdoDisconnected();
            dal.DeleteBook(bookCode);
        }
        public void UpdateBook(Book book)
        {
            //update book by using dal layer
            AdoDisconnected dal = new AdoDisconnected();
            dal.UpdateBookByBookCode(book);
        }
        public List<Book> GetAllBooks()
        {
            List<Book> lstBooks;
            AdoDisconnected dal = new AdoDisconnected();
            lstBooks = dal.SelectAllBooks();
            return lstBooks;
        }
        public Book SelectBookBybookCode(string bookCode)
        {
            Book book;
            AdoDisconnected dal = new AdoDisconnected();
            book = dal.SelectBookByBookCode(bookCode);
            return book;
        }
        public List<Book> SelectBookBybookName(string bookName)
        {
            List<Book> lstBooks = new List<Book>();
            AdoDisconnected dal = new AdoDisconnected();
            lstBooks = dal.SelectBookByBookName(bookName);
            return lstBooks;
        }
    }
}
