using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library_C__Group_Project;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

<<<<<<< Updated upstream
=======
    private LibraryLogic library = new LibraryLogic();
>>>>>>> Stashed changes
    private void BookButton_Click(object sender, RoutedEventArgs e)
    {
        BookWindow bookWindow = new BookWindow();
        bookWindow.Show();
    }
<<<<<<< Updated upstream
   
    
=======

    private void CustomerButton_Click(object sender, RoutedEventArgs e)
    {
        CustomerWindow customerWindow = new CustomerWindow(library);
        customerWindow.Show();
    }

    private void ReportButton_Click(object sender, RoutedEventArgs e)
    {

    }
>>>>>>> Stashed changes
}