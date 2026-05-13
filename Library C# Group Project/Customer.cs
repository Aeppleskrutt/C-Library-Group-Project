using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Library_C__Group_Project
{
    public class Customer 
    {
        public string Name { get; set; }
        public string CustomerID { get; set; }
        public string CustomerFee {  get; set; }

        public List<Book> LoanedBooks { get; set; } = new List<Book>();

        public Customer (string name, string customerID)
        {
            Name = name;
            CustomerID = customerID;
            CustomerFee = "0";
        }

        public void AddLoan(Book book)
        {
            //book.LoanDate = new DateTime(2026, 4, 1);
            book.LoanDate = DateTime.Now;
            LoanedBooks.Add(book);
        }

        public void RemoveLoan(Book book)
        {
            book.LoanDate = null;
            LoanedBooks.Remove(book);
        }

        public void CheckLateReturns()
        {
            double LateFeeDouble = 0;
            foreach (Book book in LoanedBooks)
            {
                DateTime? _loanDate = book.LoanDate;
                DateTime? returnDate = _loanDate?.AddDays(30);
                double overDueDays = returnDate.HasValue ? (DateTime.Now.Date - returnDate.Value.Date).TotalDays : 0;

                if (overDueDays > 0)
                {
                    LateFeeDouble += overDueDays * 10;
                }
            }

            int LateFeeInt = (int)LateFeeDouble;

            CustomerFee = LateFeeInt.ToString("0");
        }

        public void GetInfo()
        {
            foreach (Book book in LoanedBooks)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}");
            }
        }
        public override string ToString() //To let customer information be shown properaly in GUI
        {
            return $"{Name} | ID: {CustomerID} | Fee: {CustomerFee}";
        }
    }
}
