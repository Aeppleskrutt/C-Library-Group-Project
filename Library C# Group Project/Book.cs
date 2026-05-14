using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_C__Group_Project
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool Status { get; set; } // true for available, false for checked out
        public DateTime? LoanDate { get; set; } // Used to calculate due date and overdue fees
        public Queue<Customer> ReservationQueue { get; set; }
        = new Queue<Customer>(); //To keep a queue of customers who reserved a specific book.


        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Status = true; // Default a book to available whenever created 
            LoanDate = null; // Default to null, will be set whenever book is loaned out
        }

        public string GetDetails() // Gets details of the book directly formatted
        {
            string statusText = Status ? "Available" : "Checked Out";
            return $"{Title} by {Author} | ISBN: {ISBN} | Status: {statusText}";
        }

        public void SetStatus(bool status) // Changes a books status to inputed status
        {
            Status = status;
        }
        public override string ToString() //ToString method to let book information be properly shown in the UI
        {
            if (Status) 
            {
                return $"{Title} by {Author} | ISBN: {ISBN} | Status: Available";
            }
            return $"{Title} by {Author} | ISBN: {ISBN} | Status: Checked Out | Queue: {ReservationQueue.Count}";
        }

    }
}
