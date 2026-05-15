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
        public Validation(ErrorMessages errorMessages) 
        {
            this.errorMessages = errorMessages;
        }
        /*public bool CheckIfCustomerExists(List<Customer> customers, string customerID)
        {
            bool customerExists = false;
            foreach (Customer customer in customers)
            {
                if (customer.CustomerID == customerID)
                {
                    customerExists = true;
                    break;
                }
            }

            return customerExists;
        }  */

        /*public bool CheckIfBookExists(List<Book> books, string title)
        {
            bool bookExists = false;
            foreach (Book book in books)
            {
                if (book.Title == title)
                {
                    bookExists = true;
                    break;
                }
            }

            return bookExists;
        }*/

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
