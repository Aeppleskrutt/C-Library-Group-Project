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
    public partial class ReportWindow : Window
    {
        private readonly LibraryLogic library;
        public ReportWindow(LibraryLogic libraryLogic)
        {
            InitializeComponent();
            library = libraryLogic;
            LoadReport();
        }

        private void LoadReport()
        {
            var reportData = library.GenerateLoanedBooksReport();

            ReportListView.ItemsSource = reportData.Select(r => new
            {
                BookTitle = r.Book.Title,
                BookAuthor = r.Book.Author,
                BookISBN = r.Book.ISBN,
                CustomerName = r.Holder.Name
            }).ToList();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadReport();
        }
    }
}
