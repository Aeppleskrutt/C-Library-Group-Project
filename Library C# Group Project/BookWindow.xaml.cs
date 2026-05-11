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
            BooksListBox.Items.Clear(); //Clears the dispaly box for books
            List<Book>books = library.GetBooks(); //Gets the list of books from the library logic
            foreach (Book book in books)
            {
                BooksListBox.Items.Add(book);
            }
        }
        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text;
            string author = AuthorTextBox.Text;
            string isbn = ISBNTextBox.Text;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(isbn)) //checks so no fields are null/empty
            {
                MessageBox.Show
                    (
                "All fields must be filled.", 
                "Input Error", 
                MessageBoxButton.OK,
                MessageBoxImage.Error);
                //Add another message box for if the ISBN isnt unique.
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
                MessageBox.Show(
                    "Please select a book to remove.",
                    "Selection Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }
            Book selectedBook = (Book)BooksListBox.SelectedItem;
            library.RemoveBook(selectedBook.ISBN); //Removes said book from the library.
            RefreshBookList();


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
        }
    }
}
