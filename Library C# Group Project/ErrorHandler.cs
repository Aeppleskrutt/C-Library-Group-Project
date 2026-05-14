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
        public void CheckEmptyField()
        {
            MessageBox.Show(
                "All fields must be filled.",
                "Input Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        public bool CheckIfCustomerExists(List<Customer> customers, string customerID)
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
        }   

        public bool CheckIfBookExists(List<Book> books, string title)
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
        }

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
