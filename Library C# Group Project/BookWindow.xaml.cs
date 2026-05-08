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
        private List<Book> books = new List<Book>(); //Used for testing the program
        public BookWindow()
        {
            InitializeComponent();
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

            Book newBook = new Book(title, author, isbn);
            books.Add(newBook); //Used for testing the program
            BooksListBox.Items.Add(newBook.GetDetails());

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
           
            int selectedIndex = BooksListBox.SelectedIndex; //Which book in the GUI list is selected
            books.RemoveAt(selectedIndex); //Removes said book from the GUI.
            BooksListBox.Items.RemoveAt(selectedIndex); //Removes said book from the list.

        }
    }
}
