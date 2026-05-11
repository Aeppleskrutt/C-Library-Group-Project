using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Library_C__Group_Project
{
    class Customer
    {
        public string Name { get; set; }
        public string CustomerID { get; set; }
        public int LateFee { get; set; }
        public List<Book> LoanedBooks { get; set; } = new List<Book>();

        public Customer (string name, string customerID)
        {
            Name = name;
            CustomerID = customerID;
            LateFee = 0;
        }

        public void AddLoan(Book book)
        {
            book.LoanDate = DateTime.Now;
            LoanedBooks.Add(book);
        }

        public void RemoveLoan(Book book)
        {
            book.LoanDate = null;
            LoanedBooks.Remove(book);
        }


        public void GetInfo()
        {
            foreach (Book book in LoanedBooks)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}");
            }
        }
    }
}
