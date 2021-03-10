using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //Sql Server Provider
using System.Data;

namespace BOOKSTOREApp
{
    class AdoConnected:IDataInterface
    {
        SqlConnection con;
        SqlCommand cmd;
        public AdoConnected()
        {
            //create and configure the connection object
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-SDB1BH2\SQLEXPRESS;Initial Catalog=BOOKSTORE;Integrated Security=True";
        }
        public void DeleteBook(int bookID)
        {
            try
            {
                // TODO DELETE using AD0.NET
                //configure SqlCommand for DELETE
                cmd = new SqlCommand();
                cmd.CommandText = "delete from tbl_book where bookid=@bid";
                cmd.CommandType = CommandType.Text;

                //Supply parameters values
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@bid", bookID);

                //attach the connection
                cmd.Connection = con;

                //open connection
                con.Open();

                //Execute the command
                int recordsAffected = cmd.ExecuteNonQuery();
                if (recordsAffected == 0)
                {
                    throw new Exception("Book ID does not exist, could not perform delete");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                //close the connection
                con.Close();
            }
        }
        public void InsertBook(Book book)
        {
            try
            {
                //TODO INSERT using AD0.NET
                //configure sqlcommand for INSERT
                cmd = new SqlCommand();
                cmd.CommandText = "insert into tbl_book values(@bid,@bname,@aname,@pub,@no_items,@price)";
                //value of parameters supplied from book
                cmd.CommandType = CommandType.Text;

                //supply parameters values
                cmd.Parameters.Clear(); //always clear that
                cmd.Parameters.AddWithValue("@bid", book.BookID);
                cmd.Parameters.AddWithValue("@bname", book.BookName);
                cmd.Parameters.AddWithValue("@aname", book.AuthorName);
                cmd.Parameters.AddWithValue("@pub", book.Publisher);
                cmd.Parameters.AddWithValue("@no_items", book.NoOfCopies);
                cmd.Parameters.AddWithValue("@price", book.Price);

                //attaching the connection
                cmd.Connection = con;

                //open connection
                con.Open();

                //execute the command
                int recordsAffected = cmd.ExecuteNonQuery();
                if (recordsAffected == 0)
                {
                    throw new Exception("Could not insert record");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //close connection
                con.Close();
            }
        }
        public List<Book> SelectAllBooks()
        {
            List<Book> lstBooks = new List<Book>();

            //configure SQL command for select all
            cmd = new SqlCommand();
            cmd.CommandText = "select bookid,bookname,authorname,publisher,[no of copies],price from tbl_book";
            cmd.CommandType = CommandType.Text;

            //attach connection with the command
            cmd.Connection = con;

            //open the connection
            con.Open();

            //execute the command
            SqlDataReader sdr = cmd.ExecuteReader();

            //traverse the records of the DataReader one-by-one
            while (sdr.Read())
            {
                Book book = new Book
                {
                    BookID = (int)sdr[0],
                    BookName = sdr[1].ToString(),
                    AuthorName = sdr[2].ToString(),
                    Publisher = sdr[3].ToString(),
                    NoOfCopies = (int)sdr[4],
                    Price = (int)sdr[5]
                };
                //add the employee record to the collection
                lstBooks.Add(book);
            }
            sdr.Close();
            con.Close();
            return lstBooks;
        }
        public Book SelectBookById(int bookID)
        {
            Book book;
            try
            {
                //TODO SELECT by Emp ID using AD0.NET
                //configure sqlcommand for Select
                cmd = new SqlCommand();
                cmd.CommandText = "select bookid,bookname,authorname,publisher,[no of copies],price from tbl_book where bookid=@bid";
                //value of parameters supplied from emp
                cmd.CommandType = CommandType.Text;

                //supply parameter
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@bid", bookID);

                cmd.Connection = con;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    book = new Book
                    {
                        BookID = (int)sdr[0],
                        BookName = sdr[1].ToString(),
                        AuthorName = sdr[2].ToString(),
                        Publisher = sdr[3].ToString(),
                        NoOfCopies = (int)sdr[4],
                        Price = (int)sdr[5]
                    };
                    sdr.Close();
                }
                else
                {
                    throw new Exception("BookId does not exist.......");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return book;
        }
        public void UpdateBookById(Book book)
        {
            try
            {
                //TODO UPDATE using AD0.NET
                //configure sqlcommand for UPDATE
                cmd = new SqlCommand();
                cmd.CommandText = "update tbl_employee set bookname=@bname,authorname=@aname,publisher=@pub," +
                    "[no of copies]=@no_items,price=@price where bookid=@bid";
                //value of parameters supplied from emp
                cmd.CommandType = CommandType.Text;

                //supply parameters values
                cmd.Parameters.Clear(); //always clear that
                cmd.Parameters.AddWithValue("@bid", book.BookID);
                cmd.Parameters.AddWithValue("@bname", book.BookName);
                cmd.Parameters.AddWithValue("@aname", book.AuthorName);
                cmd.Parameters.AddWithValue("@pub", book.Publisher);
                cmd.Parameters.AddWithValue("@no_items", book.NoOfCopies);
                cmd.Parameters.AddWithValue("@price", book.Price);

                //attaching the connection
                cmd.Connection = con;

                //open connection
                con.Open();

                //execute the command
                int recordsAffected = cmd.ExecuteNonQuery();
                if (recordsAffected == 0)
                {
                    throw new Exception("BookId does not exist, Could not perform the update");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //close connection
                con.Close();
            }
        }
    }
}
