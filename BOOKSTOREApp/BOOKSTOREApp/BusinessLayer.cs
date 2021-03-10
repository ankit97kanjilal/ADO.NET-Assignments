using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOKSTOREApp
{
    class BusinessLayer
    {
        public List<Book> GetAllBooks()
        {
            List<Book> lstBooks = new List<Book>();
            //get the records from Data Access Layer
            AdoConnected dal = new AdoConnected();
            lstBooks = dal.SelectAllBooks();
            return lstBooks;
        }
        public void AddBook(Book book)
        {
            AdoConnected dal = new AdoConnected();
            dal.InsertBook(book);
        }
        public void DeleteBook(int bookID)
        {
            AdoConnected dal = new AdoConnected();
            dal.DeleteBook(bookID);
        }
        public void UpdateBook(Book book)
        {
            //update using dal layer
            AdoConnected dal = new AdoConnected();
            dal.UpdateBookById(book);
        }
        public Book SelectBookById(int bookID)
        {
            AdoConnected dal = new AdoConnected();
            Book book = dal.SelectBookById(bookID);
            return book;
        }
    }
}
