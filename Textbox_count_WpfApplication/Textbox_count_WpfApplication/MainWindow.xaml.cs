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

namespace Textbox_count_WpfApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            boxeins.KeyUp += changed;       // zählt
        }

        private void changed(object sender, RoutedEventArgs e)
        {
            labelBuchstaben.Content = "Anzahl Buchstaben" + "\n" + boxeins.Text.Length;
            labelWorte.Content = "Anzahl Worte" + "\n" + (boxeins.Text.Split(' ').Length).ToString();
        }
    }
}
