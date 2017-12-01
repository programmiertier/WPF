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

namespace Spieler_WpfApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Spieler.laufende = 1;
            for (int zaehl = 1; zaehl <= 11; zaehl++)
            {
                Spieler spnr = new Spieler();
                // n.spieler.MouseDown += Wagen_MouseDown;
                Label l = new Label();
                StackPanel p = new StackPanel();
                p.Children.Add(spnr.spieler);
                l.Content = spnr.rueckennummer;
                dasFeld.Children.Add(l);
                dasFeld.Children.Add(p);
                Grid.SetRow(l, spnr.row);
                Grid.SetColumn(l, spnr.column);
                Grid.SetRow(p, spnr.row);
                Grid.SetColumn(p, spnr.column);
            }
        }
    }
}
