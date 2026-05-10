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
        private List<Book> books = new List<Book>(); //Used for testing the program
        public BookWindow()
        {
            InitializeComponent();
        }
<<<<<<< Updated upstream

=======
        private void RefreshBookList()
        {
            BooksListBox.Items.Clear(); //Clears the display box for books
            foreach (Book book in library.Books)
            {
                BooksListBox.Items.Add(book); //Reads and adds each book back to the display
            }
        }
>>>>>>> Stashed changes
        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text;
            string author = AuthorTextBox.Text;
            string isbn = ISBNTextBox.Text;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(isbn)) //checks so no fields are null/empty
            {
                MessageBox.Show(
                "All fields must be filled.", 
                "Input Error", 
                MessageBoxButton.OK,
                MessageBoxImage.Error);
                return;
            }
            bool bookExists = library.Books.Any(b => b.ISBN == isbn); // To make sure the ISBN is unique
            if (bookExists)
            {
                MessageBox.Show(
                    "A book with this ISBN already exists.",
                    "Input Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

<<<<<<< Updated upstream
            Book newBook = new Book(title, author, isbn);
            books.Add(newBook); //Used for testing the program
            BooksListBox.Items.Add(newBook.GetDetails());
=======
            library.AddBook(title, author, isbn); //Calls method to add book
            RefreshBookList();
>>>>>>> Stashed changes

            TitleTextBox.Clear();
            AuthorTextBox.Clear();
            ISBNTextBox.Clear();
        }

        private void RemoveBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (BooksListBox.SelectedIndex == -1) //If no book is selected.
            {
                MessageBox.Show(
                    "Please select a book to remove.",
                    "Selection Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }
<<<<<<< Updated upstream
           
            int selectedIndex = BooksListBox.SelectedIndex; //Which book in the GUI list is selected
            books.RemoveAt(selectedIndex); //Removes said book from the GUI.
            BooksListBox.Items.RemoveAt(selectedIndex); //Removes said book from the list.

=======

            MessageBoxResult result = MessageBox.Show( //Shows a message box to confirm the user wants to remove the book
            "Are you sure you want to remove this book?",
            "Confirm Removal",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Book selectedBook = (Book)BooksListBox.SelectedItem;
                library.RemoveBook(selectedBook.ISBN); //Removes said book from the library.
                RefreshBookList();
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text;
            BooksListBox.Items.Clear();

            //Need a method, likely in Librarylogic that searches the list.
            //Will update whenever said method is created

        }

        private void ShowAllButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshBookList();
>>>>>>> Stashed changes
        }
    }
}
