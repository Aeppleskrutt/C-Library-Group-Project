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
using static System.Reflection.Metadata.BlobBuilder;



namespace Library_C__Group_Project
{
    public partial class BookWindow : Window
    {
        private LibraryLogic library;
        public BookWindow(LibraryLogic libraryLogic)
        {
            InitializeComponent();
            library = libraryLogic;
            RefreshBookList(); //Refreshes book list on launch, this is to ensure starting a window after closing will still show all books
        }
        private void RefreshBookList()
        {
            BooksListBox.Items.Clear(); //Clears the display box for books
            List<Book> books = library.GetBooks(); //Gets the list of books from the library logic
            foreach (Book book in books)
            {
                BooksListBox.Items.Add(book);
            }
        }
        private void RefreshReservationQueue(Book selectedBook)
        {
            ReservationQueueListBox.Items.Clear();
            foreach (Customer customer in selectedBook.ReservationQueue)
            {
                ReservationQueueListBox.Items.Add(customer.Name);
            }
        }
        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text;
            string author = AuthorTextBox.Text;
            string isbn = ISBNTextBox.Text;

            if(library.Validation.ProcessString(title) || library.Validation.ProcessString(author) || library.Validation.ProcessString(isbn)) //checks so no fields are null/empty
            {
                return;
            }

            bool bookExists = library.Books.Any(b => b.ISBN == isbn); // To make sure the ISBN is unique
            if (bookExists)
            {
                library.ErrorMessages.BookExistError();
                return;
            }

            if (isbn.Length != 13)
            {
                library.ErrorMessages.ISBNError();
                return;
            }

            library.AddBook(title, author, isbn); //Calls method to add book
            RefreshBookList();

            TitleTextBox.Clear(); //Clears text boxes to avoid confusion for user
            AuthorTextBox.Clear();
            ISBNTextBox.Clear();
        }

        private void RemoveBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (BooksListBox.SelectedIndex == -1) //If no book is selected.
            {
                library.ErrorMessages.RemoveBookError();
                return;
            }
            MessageBoxResult result = MessageBox.Show( //Shows a message box to confirm the user wants to remove the book
                "Are you sure you want to remove this book?",
                "Confirm Removal",
                 MessageBoxButton.YesNo,
                 MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Book selectedBook = (Book)BooksListBox.SelectedItem;
                library.RemoveBook(selectedBook.ISBN); //Removes said book from the library.
                BooksListBox.Items.Remove(selectedBook); //Removes the book from the display as well
            }
            
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            BooksListBox.Items.Clear();
            string searchText = SearchTextBox.Text;
            var results = library.GetBookByName(searchText);
            foreach (var book in results)
            {
                BooksListBox.Items.Add(book);
            }
        }

        private void ShowAllButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshBookList();
        }

        private void BooksListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BooksListBox.SelectedItem != null)
            {
                Book selectedBook = (Book)BooksListBox.SelectedItem;
                RefreshReservationQueue(selectedBook);
            }
        }
    }
}
