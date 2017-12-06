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

namespace Raumberechnung_WpfApplication
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

        private void vertikal_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            knopf.Height = vertikal.Value;
            knopf.Content = vertikal.Value * horizontal.Value;
            knopf.Content = ("Höhe " + vertikal.Value + "\n" + " mal " + horizontal.Value + "Breite" + "\n" + " ist " + vertikal.Value * horizontal.Value);
            // knopf.Height = knopf.ActualHeight + vertikal.Value;
        }

        private void horizontal_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            knopf.Width = horizontal.Value;
            knopf.Content = ("Höhe " + vertikal.Value + "\n" + " mal " + horizontal.Value + "Breite" + "\n" + " ist " + vertikal.Value * horizontal.Value);
            // knopf.Width = knopf.ActualWidth + horizontal.Value;
            // knopf.Content = knopf.Height + horizontal
        }

    }
}
