/*
Q1. ADO.NET Exercises
1.2 Book Store application 
It is an application through which an owner of the book store will be able to manipulate records from a database 
table maintained by that book store 

1.2.1 Objective 
To get to know how to interact with database in disconnected(do in connected mode) manner.. 

1.2.2 Problem Statement 
You need to develop an application for a book store where owner of the store will be able to 

a. Find out any book from the database with the help of the book name, along with numerous details about the book.
The database should maintain a table, BookDetailstable containing following information: 
1. Book Name 
2. Book Id (primary key) 
3. Author Name 
4. Publisher name 
5. No of copies 
6. Price 

The data should be retrieved in a disconnected manner. 
Note: If the owner does not remember the full name of the book, he/she can use partial name (few characters 
in that name) of the book to search the book.

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOKSTOREApp
{
    //UI Layer for BOOKS App
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("1.Add book");
                Console.WriteLine("2.Delete book By Id");
                Console.WriteLine("3.Update book By Id");
                Console.WriteLine("4.Display All books");
                Console.WriteLine("5.Search book By Id");
                Console.WriteLine("6.Search book By Book name");
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
            Console.Write("Enter the book ID : ");
            book.BookID = int.Parse(Console.ReadLine());
            Console.Write("Enter the book name : ");
            book.BookName = Console.ReadLine();
            Console.Write("Enter the author name : ");
            book.AuthorName = Console.ReadLine();
            Console.Write("Enter the publisher name : ");
            book.Publisher = Console.ReadLine();
            Console.Write("Enter the number of this book : ");
            book.NoOfCopies = int.Parse(Console.ReadLine());
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
                int bookID = int.Parse(Console.ReadLine());
                bll.DeleteBook(bookID);
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
                book.BookID = int.Parse(Console.ReadLine());
                Console.Write("Enter the book name for update : ");
                book.BookName = Console.ReadLine();
                Console.Write("Enter the author name for update : ");
                book.AuthorName = Console.ReadLine();
                Console.Write("Enter the publisher name for update : ");
                book.Publisher = Console.ReadLine();
                Console.Write("Enter the number of this book for update : ");
                book.NoOfCopies = int.Parse(Console.ReadLine());
                Console.Write("Enter the book price for update : ");
                book.Price = int.Parse(Console.ReadLine());

                BusinessLayer bll = new BusinessLayer();
                bll.UpdateBook(book);
                Console.WriteLine("Updated record successfully");
            }
            catch(Exception ex)
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
                Console.WriteLine(book.BookID + "\t\t" + book.BookName + "\t\t" + book.AuthorName + "\t\t"
                    + book.Publisher + "\t\t" + book.NoOfCopies + "\t\t" + book.Price);
            }
        }
        static void SearchBookById()
        {
            try
            {
                int bookID;
                Book book = null;
                Console.Write("Enter bookID for search : ");
                bookID = int.Parse(Console.ReadLine());
                //search book using business layer
                BusinessLayer bll = new BusinessLayer();
                book = bll.SelectBookById(bookID);
                Console.WriteLine(book.BookID + "\t\t" + book.BookName + "\t\t" + book.AuthorName + "\t\t"
                    + book.Publisher + "\t\t" + book.NoOfCopies + "\t\t" + book.Price);
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
                Console.Write("Enter the book name to search : ");
                string bookName = Console.ReadLine();
                //search book using business layer
                BusinessLayer bll = new BusinessLayer();
                Book book = bll.SelectBookByBookName(bookName);
                Console.WriteLine(book.BookID + "\t\t" + book.BookName + "\t\t" + book.AuthorName + "\t\t"
                        + book.Publisher + "\t\t" + book.NoOfCopies + "\t\t" + book.Price);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
