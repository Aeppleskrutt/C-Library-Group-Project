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
            //This method is called at start of program in MainWindow
            double LateFeeDouble = 0;
            foreach (Book book in LoanedBooks)
            {
                DateTime? _loanDate = book.LoanDate; //_loanDate is set to when the specific book was loand
                DateTime? returnDate = _loanDate?.AddDays(30); //returnDate is set to 30 days after the book was loand
                //The return date is subtracted from todays date, if the amount of days is larger then 0 the fee will be added
                double overDueDays = returnDate.HasValue ? (DateTime.Now.Date - returnDate.Value.Date).TotalDays : 0;

                if (overDueDays > 0)
                {
                    LateFeeDouble += overDueDays * 10;
                }
            }

            CustomerFee = LateFeeDouble.ToString("0"); //ToString so the text can be showned in the window
        }

        public override string ToString() //To let customer information be shown properaly in GUI
        {
            return $"{Name} | ID: {CustomerID} | Fee: {CustomerFee}";
        }
    }
}
