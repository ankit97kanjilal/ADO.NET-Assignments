using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Entity Class
namespace BookStoreApp2
{
    class Book
    {
        public string BookCode { get; set; }
        public string BookName { get; set; }
        public string Publisher { get; set; }
        public string AuthorName { get; set; }
        public int Price { get; set; }
    }
}
