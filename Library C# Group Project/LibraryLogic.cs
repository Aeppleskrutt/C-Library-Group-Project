using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_C__Group_Project
{
    public class LibraryLogic
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public ErrorMessages ErrorMessages { get; set; } = new ErrorMessages();
        public Validation Validation { get; set; }

        public LibraryLogic()
        {
            Validation = new Validation(ErrorMessages, this);
        }


        public List<Book> GetBooks()
        {
            return Books;
        }

        public List<Customer> GetCustomers()
        {
            return Customers;
        }

        public void Testing()
        {
            AddBook("Harry Potter", "Rowling", "0000000000001");
            AddBook("Star Wars", "Lucas", "0000000000002");
            AddBook("The Hobbit", "Tolkien", "0000000000003");
            Customers.Add(new Customer("Johan", "001"));
            Customers.Add(new Customer("Lars", "002"));
            Customers.Add(new Customer("Lisa", "003"));
        }
        public void AddBook(string title, string author, string isbn)
        {
            Books.Add(new Book(title, author, isbn));
        }
        public void RemoveBook(string isbn)
        {
            Book? bookToRemove = Books.FirstOrDefault(b => b.ISBN == isbn);
            if (bookToRemove != null)
            {
                Books.Remove(bookToRemove);
            }
        }
        public void LoanBook(string isbn, string customerId)
        {
            Book? bookToLoan = Books.FirstOrDefault(b => b.ISBN == isbn && b.Status);
            Customer? customer = Customers.FirstOrDefault(c => c.CustomerID == customerId);
            if (bookToLoan != null && customer != null)
            {
                bookToLoan.SetStatus(false);
                customer.AddLoan(bookToLoan);
            }
        }
        public void ReturnBook(string isbn, string customerId)
        {
            Customer? customer = Customers.FirstOrDefault(c => c.CustomerID == customerId);
            if (customer != null)
            {
                Book? bookToReturn = customer.LoanedBooks.FirstOrDefault(b => b.ISBN == isbn);
                if (bookToReturn != null)
                {
                    bookToReturn.SetStatus(true);
                    customer.RemoveLoan(bookToReturn);
                    if (bookToReturn.ReservationQueue.Count > 0)
                    {
                        Customer nextCustomer = bookToReturn.ReservationQueue.Dequeue();
                        bookToReturn.Status = false;
                        nextCustomer.AddLoan(bookToReturn);
                    }
                }
            }
        }
        public void GetCustomerLoans(string customerId)
        {
            Customer? customer = Customers.FirstOrDefault(c => c.CustomerID == customerId);
            if (customer != null)
            {
                customer.GetInfo();
            }
        }

        public List<Book> GetBookByName(string searchText)
        {
            return Books
            .Where(b => b.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                        b.Author.Contains(searchText, StringComparison.OrdinalIgnoreCase))
            .ToList();
        }

        public List<(Book Book, Customer Holder)> GenerateLoanedBooksReport()
        {
            var report = new List<(Book, Customer)>();
            foreach (var customer in Customers)
            {
                foreach (var book in customer.LoanedBooks)
                {
                    report.Add((book, customer));
                }
            }
            return report;
        }

    }
}
