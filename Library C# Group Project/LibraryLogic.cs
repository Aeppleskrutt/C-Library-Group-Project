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


        public List<Book> GetBooks()
        {
            return Books;
        }
        public void AddBook(string title, string author, string isbn)
        {
            Books.Add(new Book(title, author, isbn));
        }
        public void RemoveBook(string isbn)
        {
            Book bookToRemove = Books.FirstOrDefault(b => b.ISBN == isbn);
            if (bookToRemove != null)
            {
                Books.Remove(bookToRemove);
            }
        }
        public void LoanBook(string isbn, string customerId)
        {
            Book bookToLoan = Books.FirstOrDefault(b => b.ISBN == isbn && b.Status);
            Customer customer = Customers.FirstOrDefault(c => c.CustomerID == customerId);
            if (bookToLoan != null && customer != null)
            {
                bookToLoan.Status = false;
                customer.AddLoan(bookToLoan);
            }
        }
        public void ReturnBook(string isbn, string customerId)
        {
            Customer customer = Customers.FirstOrDefault(c => c.CustomerID == customerId);
            if (customer != null)
            {
                Book bookToReturn = customer.LoanedBooks.FirstOrDefault(b => b.ISBN == isbn);
                if (bookToReturn != null)
                {
                    bookToReturn.Status = true;
                    customer.RemoveLoan(bookToReturn);
                }
            }
        }
        public void GetCustomerLoans(string customerId)
        {
            Customer customer = Customers.FirstOrDefault(c => c.CustomerID == customerId);
            if (customer != null)
            {
                customer.GetInfo();
            }
        }

        public void GetBookByName(string title, string author)
        {
            Book book = Books.FirstOrDefault(b => b.Title == title || b.Author == author);
            if (book != null)
            {
                book.GetDetails();
            }
            
        }
    }
}
