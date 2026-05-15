using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Library_C__Group_Project
{
    public class ErrorMessages
    {
        public void BookExistError()
        {
            MessageBox.Show(
                    "A book with this ISBN already exists.",
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

        public void EmptyFieldError()
        {
            MessageBox.Show(
                "All fields must be filled.",
                "Input Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
        public void ISBNError()
        {
            MessageBox.Show(
                    "ISBN must be exactly 13 characters long.",
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
        public void ReservedBookError()
        {
            MessageBox.Show(
                    "Customer has already reserved or loaned this book.",
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
        public void SelectCustomerError()
        {
            MessageBox.Show(
                    "Please select a customer.",
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

        public void SelectReservedBookError()
        {
            MessageBox.Show(
                    "Please select a reserved book.",
                    "Selection Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
        }
    }
}
