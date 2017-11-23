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

namespace ButtonControls_WpfApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*Button knopf2 = new Button();
            Grid.SetRow(knopf2, 1);
            Grid.SetColumn(knopf2, 0);
            gritty.Children.Add(knopf2);    */

           
        }

        // das ist der Eventhandler, eine Methode, eine Adresse, die vom Delegaten aufgerufen wird
        public void simple_gelickt(object sender, RoutedEventArgs e)    // EventArgs würde nur den Klick annehmen und nichts weiter machen
        {
            label_simple.Content = "Simple wurde geklickt";
        }
    }
}
