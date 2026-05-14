using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Library_C__Group_Project
{
    public class ErrorHandler
    {
        public void EmptyFieldError()
        {
            MessageBox.Show(
                "All fields must be filled.",
                "Input Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        public void BookExistError()
        {
            MessageBox.Show(
                    "A book with this ISBN already exists.",
                    "Input Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
        }

        public void RemoveBookError()
        {
            MessageBox.Show(
                    "Please select a book to remove.",
                    "Selection Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
        }

        public void SelectLoandBookError()
        {
            MessageBox.Show(
                    "Please select a loaned book.",
                    "Selection Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
        }

        public void SelectAvailableBookError()
        {
            MessageBox.Show(
                    "Please select an available book.",
                    "Selection Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
        }

        public void ISBNError()
        {
            MessageBox.Show(
                    "ISBN must be exactly 13 characters long.",
                    "Input Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
        }

        public void CustomerExistError()
        {
            MessageBox.Show(
                    "A customer with this ID already exists.",
                    "Input Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
        }

        public void SelectCustomerError()
        {
            MessageBox.Show(
                    "Please select a customer.",
                    "Selection Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
        }

        public void SelectReservedBookError()
        {
            MessageBox.Show(
                    "Please select a reserved book.",
                    "Selection Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
        }
        public void ReservedBookError()
        {
            MessageBox.Show(
                    "Customer has already reserved or loaned this book.",
                    "Selection Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
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

        public string ProcessString()
        {
            string checkThisString;
            do
            {
                checkThisString = Console.ReadLine();
                if (String.IsNullOrEmpty(checkThisString))
                {
                    Console.WriteLine("The string can't be empty!");
                }
                else
                {
                    break;
                }
            } while (true);

            return checkThisString;
        }

        public void ProcessISBN(string ISBN)
        {
            if(ISBN.Length != 13)
            {
                Console.WriteLine("Needs to be 13 characters!");
            }
        }

    }
}
