using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_C__Group_Project
{
    class Customer
    {
        public string Name { get; set; }
        public string CustomerID { get; set; }
        public List<Book> LoanedBooks { get; set; } = new List<Book>();
    }

    //To Do: Methods for this class

    //AddLoan();

    //RemoveLoan();

    //GetInfo();
}
