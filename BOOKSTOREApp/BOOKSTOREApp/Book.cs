using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOKSTOREApp
{
    class Book
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string Publisher { get; set; }
        public int  NoOfCopies{ get; set; }
        public int Price { get; set; }
    }
}
