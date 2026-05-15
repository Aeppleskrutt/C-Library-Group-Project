using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_C__Group_Project
{
    public class Validation
    {
        private ErrorMessages errorMessages;
        private LibraryLogic library;
        
        public Validation(ErrorMessages errorMessages, LibraryLogic library) 
        {
            this.errorMessages = errorMessages;
            this.library = library;
        }
        
        public bool CheckIfCustomerExists(string customerID)
        {
            bool customerExists = false;
            List<Customer> _customers = library.GetCustomers();
            foreach (Customer customer in _customers)
            {
                if (customer.CustomerID == customerID)
                {
                    customerExists = true;
                    library.ErrorMessages.CustomerExistError();
                    break;
                }
            }

            return customerExists;
        }  

        public bool CheckIfBookExists(string isbn)
        {
            bool bookExists = false;
            List<Book> books = library.GetBooks();
            foreach (Book book in books)
            {
                if (book.ISBN == isbn)
                {
                    bookExists = true;
                    library.ErrorMessages.BookExistError();
                    break;
                }
            }

            return bookExists;
        }

        public bool ProcessString(String checkThisString)
        {
            bool isEmpty = false;
            if (string.IsNullOrWhiteSpace(checkThisString))
            {
                errorMessages.EmptyFieldError();
                isEmpty = true;
            }                       
            return isEmpty;
        }

        public bool ProcessISBN(string ISBN)
        {
            bool isThirteen = true;
            if (ISBN.Length != 13)
            {
                errorMessages.ISBNError();
                isThirteen = false;
            }
            return isThirteen;
        }
    }
}
