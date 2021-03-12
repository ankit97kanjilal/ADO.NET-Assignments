using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BookStoreApp2
{
    class AdoDisconnected : IDataDisconnected
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        public AdoDisconnected()
        {
            //create and configure the connection object
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-SDB1BH2\SQLEXPRESS;Initial Catalog=BOOKSTORE;Integrated Security=True";

            //configure DataAdapter
            da = new SqlDataAdapter("select bookcode,bookname,publisher,authorname,price from BookTable", con);

            //create dataset and fill the result using DataAdapter
            ds = new DataSet();
            da.Fill(ds, "BookTable");

            //add constraints inside dataset table also by C#
            ds.Tables[0].Constraints.Add("pk_key", ds.Tables[0].Columns[0], true);
            //where ever we call find() we need pk
            //in disconnected mode... we can use stored procedure only for 
        }
        public void DeleteBook(string bookCode)
        {
            //find the row in the DataSet Table's rows
            DataRow row = ds.Tables[0].Rows.Find(bookCode);
            //delete the row found
            if (row != null)
            {
                row.Delete();
                //save to database using DataAdapter
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(ds, "BookTable");
            }
            else
            {
                throw new Exception("BookCode does not exist, could not perform deletion");
            }
        }
        public void InsertBook(Book book)
        {
            //1. Create a new row from the DataSet Table
            DataRow row = ds.Tables[0].NewRow();
            //2. supply values to the newly created row
            row[0] = book.BookCode;
            row[1] = book.BookName;
            row[2] = book.Publisher;
            row[3] = book.AuthorName;
            row[4] = book.Price;
            //attach the newly created DataRow to the DataSet table's rows 
            ds.Tables[0].Rows.Add(row);
            //save the changes from DataSet to Database using DataAdapter
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(ds, "BookTable");
        }
        public List<Book> SelectAllBooks()
        {
            List<Book> lstBooks = new List<Book>();
            //TODO Traverse each record of the DataSet Table and add them to the collection
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Book book = new Book
                {
                    BookCode = row[0].ToString(),
                    BookName = row[1].ToString(),
                    Publisher = row[2].ToString(),
                    AuthorName = row[3].ToString(),
                    Price = (int)row[4]
                };

                //add the current row to the collection
                lstBooks.Add(book);
            }
            return lstBooks;
        }
        public Book SelectBookByBookCode(string bookCode)
        {
            DataRow row = ds.Tables[0].Rows.Find(bookCode);
            if (row != null)
            {
                Book book = new Book
                {
                    BookCode = row[0].ToString(),
                    BookName = row[1].ToString(),
                    Publisher = row[2].ToString(),
                    AuthorName = row[3].ToString(),
                    Price = (int)row[4]
                };
                return book;
            }
            else
            {
                throw new Exception("Ecode does not exist");
            }
        }
        public List<Book> SelectBookByBookName(string bookName)
        {
            List<Book> lstBooks = new List<Book>();
            DataRow[] rows = ds.Tables[0].Select("bookname=" + "'" + bookName + "'");
            if (rows != null)
            {
                foreach (DataRow dr in rows)
                {
                    Book book = new Book
                    {
                        BookCode = dr[0].ToString(),
                        BookName = dr[1].ToString(),
                        Publisher = dr[2].ToString(),
                        AuthorName = dr[3].ToString(),
                        Price = (int)dr[4]
                    };
                    lstBooks.Add(book);
                }
                return lstBooks;
            }
            else
            {
                throw new Exception("BookName not found... Details not allowed..");
            }            
        }
        public void UpdateBookByBookCode(Book book)
        {
            //find the row in the DataSet Table's rows 
            DataRow row = ds.Tables[0].Rows.Find(book.BookCode);
            //update the row found
            if (row != null)
            {
                row[0] = book.BookCode;
                row[1] = book.BookName;
                row[2] = book.Publisher;
                row[3] = book.AuthorName;
                row[4] = book.Price;
                //save to database using DataAdapter
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(ds, "BookTable");
            }
            else
            {
                throw new Exception("Ecode does not exist, could not perform updation");
            }
        }
    }
}
