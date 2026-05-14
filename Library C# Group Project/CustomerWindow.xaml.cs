using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Library_C__Group_Project
{
    public partial class CustomerWindow : Window
    {
        private LibraryLogic library;

        public CustomerWindow(LibraryLogic librarylogic)
        {
            InitializeComponent();
            library = librarylogic;

            RefreshCustomerList();
            RefreshAvailableBooks();
            RefreshReservedBooks();
            //The refreshes run to make sure that added books and customers are shown correctly
        }

        private void RefreshCustomerList() //To ensure correct information is always dispalyed
        {
            CustomersListBox.Items.Clear(); //Clears the display box for customers
            foreach (Customer customer in library.Customers)
            {
                CustomersListBox.Items.Add(customer); //Reads and adds each customer back to the display
            }
        }

        private void RefreshAvailableBooks() //To make available books display correctly
        {
            AvailableBooksComboBox.Items.Clear();
            foreach (Book book in library.Books)
            {
                if (book.Status) //Makes sure only available books are added to the box
                {
                    AvailableBooksComboBox.Items.Add(book);
                }
            }
        }
        private void RefreshReservedBooks()
        {
            ReservedBooksComboBox.Items.Clear();

            foreach (Book book in library.Books)
            {
                if (!book.Status)
                {
                    ReservedBooksComboBox.Items.Add(book);
                }
            }
        }

        private void RefreshLoanedBooks(Customer customer) //To make loaned books display correctly
        {
            LoanedBooksListBox.Items.Clear();
            foreach (Book book in customer.LoanedBooks) //Checks specific customers for their loaned books
            {
                LoanedBooksListBox.Items.Add(book);
            }
        }

        private void AddCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string customerID = CustomerIDTextBox.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(customerID))
            {
                library.ErrorHandler.EmptyFieldError();
                return;
            }

            bool customerExists = library.Customers.Any(c => c.CustomerID == customerID); // To make sure the customer ID is unique
            if (customerExists)
            {
                library.ErrorHandler.CustomerExistError();
                return;
            }

            library.Customers.Add(new Customer(name, customerID)); //No method to add a customer?
            RefreshCustomerList();

            NameTextBox.Clear();
            CustomerIDTextBox.Clear();
        }

        private void RemoveCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersListBox.SelectedIndex == -1) //If no customer is selected.
            {
                library.ErrorHandler.SelectCustomerError();
                return;
            }

            MessageBoxResult result = MessageBox.Show( //Shows a message box to confirm the user wants to remove the customer
                "Are you sure you want to remove this customer?",
                "Confirm Removal",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Customer selectedCustomer = (Customer)CustomersListBox.SelectedItem;
                library.Customers.Remove(selectedCustomer); //Removes said customer from the library.
                RefreshCustomerList();
            }
        }

        private void CustomersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CustomersListBox.SelectedItem != null)
            {
                Customer selectedCustomer = (Customer)CustomersListBox.SelectedItem;
                RefreshLoanedBooks(selectedCustomer); //Adds the loaned books of the selected customer to the list
            }
        }

        private void LoanBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersListBox.SelectedItem == null)
            {
                library.ErrorHandler.SelectCustomerError();
                return;
            }

            if (AvailableBooksComboBox.SelectedItem == null)
            {
                library.ErrorHandler.SelectAvailableBookError();
                return;
            }

            Customer selectedCustomer = (Customer)CustomersListBox.SelectedItem;
            Book selectedBook = (Book)AvailableBooksComboBox.SelectedItem;
            library.LoanBook(selectedBook.ISBN, selectedCustomer.CustomerID);

            RefreshLoanedBooks(selectedCustomer);
            RefreshAvailableBooks();
            RefreshReservedBooks();
            /*foreach (Customer customer in library.Customers)
            {
                customer.CheckLateReturns(); //Checks for late returns to make sure fees are up to date
            }
            RefreshCustomerList(); //FOR TESTING PURPOSES ONLY, CAN BE REMOVED*/
            //Refreshes the lists to make sure loaned/available books display correctly
        }

        private void ReturnBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersListBox.SelectedItem == null)
            {
                library.ErrorHandler.SelectCustomerError();
                return;
            }

            if (LoanedBooksListBox.SelectedItem == null)
            {
                library.ErrorHandler.SelectLoandBookError();
                return;
            }

            Customer selectedCustomer = (Customer)CustomersListBox.SelectedItem;
            Book selectedBook = (Book)LoanedBooksListBox.SelectedItem;
            library.ReturnBook(selectedBook.ISBN, selectedCustomer.CustomerID);

            RefreshLoanedBooks(selectedCustomer);
            RefreshAvailableBooks();
            RefreshReservedBooks();
            //Refreshes the lists to make sure loaned/available books display correctly
        }

        private void ReserveBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersListBox.SelectedItem == null)
            {
                library.ErrorHandler.SelectCustomerError();
                return;
            }
            if (ReservedBooksComboBox.SelectedItem == null)
            {
                library.ErrorHandler.SelectReservedBookError();
                return;
            }

            Customer selectedCustomer = (Customer)CustomersListBox.SelectedItem;
            Book selectedBook = (Book)ReservedBooksComboBox.SelectedItem;
            if (selectedBook.ReservationQueue.Contains(selectedCustomer) || selectedCustomer.LoanedBooks.Contains(selectedBook))
            {
                library.ErrorHandler.ReservedBookError();
                return;
            }
            selectedBook.ReservationQueue.Enqueue(selectedCustomer);
            MessageBox.Show($"{selectedCustomer.Name} reserved {selectedBook.Title}");

            RefreshAvailableBooks();
            RefreshReservedBooks();
            //Refreshes the lists to make sure loaned/available books display correctly
        }
    }
}
