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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FourFunctionCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window // Main window class
    {
        public CalcVM ViewModel { get; private set; } // Declares a view model
        public MainWindow() // Constructs the window
        {
            ViewModel = new CalcVM(); // Initializes the view mdoel
            DataContext = this; // Sets the DataContext, the source of all entities. Used to connect to LINQ or SQL
            InitializeComponent(); // Builds the interface
        }
    }
}
