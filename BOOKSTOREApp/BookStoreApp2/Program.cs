using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("1.Add book");
                Console.WriteLine("2.Delete book By BookCode");
                Console.WriteLine("3.Update book By BookCode");
                Console.WriteLine("4.Display All books");
                Console.WriteLine("5.Search book By BookCode");
                Console.WriteLine("6.Search book By BookName");
                Console.WriteLine("0.Exit");
                Console.Write("Enter Choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        DeleteBookById();
                        break;
                    case 3:
                        UpdateBookById();
                        break;
                    case 4:
                        DisplayAllBooks();
                        break;
                    case 5:
                        SearchBookById();
                        break;
                    case 6:
                        SearchBookByBookName();
                        break;
                    case 0:
                        Console.WriteLine("Exiting......");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

            } while (choice != 0);
        }
        static void AddBook()
        {
            Book book = new Book();
            Console.Write("Enter the book code : ");
            book.BookCode = Console.ReadLine();
            Console.Write("Enter the book name : ");
            book.BookName = Console.ReadLine();
            Console.Write("Enter the publisher name : ");
            book.Publisher = Console.ReadLine();
            Console.Write("Enter the author name : ");
            book.AuthorName = Console.ReadLine();            
            Console.Write("Enter the book price : ");
            book.Price = int.Parse(Console.ReadLine());

            //insert using Business Layer
            BusinessLayer bll = new BusinessLayer();
            bll.AddBook(book);
            Console.WriteLine("Record inserted successfully");
        }
        static void DeleteBookById()
        {
            try
            {
                BusinessLayer bll = new BusinessLayer();
                Console.Write("Enter the bookID to delete the book detail : ");
                string bookCode = Console.ReadLine();
                bll.DeleteBook(bookCode);
                Console.WriteLine("Record deleted successfully....");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void UpdateBookById()
        {
            try
            {
                Book book = new Book();
                Console.Write("Enter the book ID for update : ");
                book.BookCode = Console.ReadLine();
                Console.Write("Enter the book name for update : ");
                book.BookName = Console.ReadLine();
                Console.Write("Enter the publisher name for update : ");
                book.Publisher = Console.ReadLine();
                Console.Write("Enter the author name for update : ");
                book.AuthorName = Console.ReadLine();
                Console.Write("Enter the book price for update : ");
                book.Price = int.Parse(Console.ReadLine());

                BusinessLayer bll = new BusinessLayer();
                bll.UpdateBook(book);
                Console.WriteLine("Updated record successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void DisplayAllBooks()
        {
            BusinessLayer bll = new BusinessLayer();
            List<Book> lstBooks = bll.GetAllBooks();
            foreach (Book book in lstBooks)
            {
                Console.WriteLine(book.BookCode + "\t\t" + book.BookName + "\t\t" + book.Publisher + "\t\t"
                    + book.AuthorName + "\t\t" + book.Price);
            }
        }
        static void SearchBookById()
        {
            try
            {
                string bookCode;
                Book book = null;
                Console.Write("Enter bookID for search : ");
                bookCode = Console.ReadLine();
                //search book using business layer
                BusinessLayer bll = new BusinessLayer();
                book = bll.SelectBookBybookCode(bookCode);
                Console.WriteLine(book.BookCode + "\t\t" + book.BookName + "\t\t" + book.Publisher + "\t\t"
                    + book.AuthorName + "\t\t" + book.Price);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void SearchBookByBookName()
        {
            try
            {
                List<Book> lstBooks = new List<Book>();
                Console.Write("Enter the book name to search : ");
                string bookName = Console.ReadLine();
                //search book using business layer
                BusinessLayer bll = new BusinessLayer();                
                lstBooks = bll.SelectBookBybookName(bookName);
                foreach (Book book in lstBooks)
                {
                    Console.WriteLine(book.BookCode + "\t\t" + book.BookName + "\t\t" + book.Publisher + "\t\t"
                        + book.AuthorName + "\t\t" + book.Price);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
