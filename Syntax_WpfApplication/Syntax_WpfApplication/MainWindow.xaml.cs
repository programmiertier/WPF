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

namespace Syntax_WpfApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /*knopf1.Content = "kno1";
            knopf2.Content = "kno2";
            knopf3.Content = "kno3 weil er so toll is";
            knopf4.Content = "kno4";*/


            // schleife
            /* for (int zaehl = 0; zaehl < 50; zaehl++)
            {
                Button knopf = new Button();
                knopf.Name = "knopf_" + zaehl.ToString();
                knopf.Content = "k" + zaehl.ToString();
                knopf.BorderThickness = new Thickness(4, 4, 4, 4);
                knopf.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 200, 0));
                anzeigefeld.Children.Add(knopf);
            }
            */
            /*int z;
            z = anzeigefeld.Children.Count;
            anzahlAnzeige.Content = "es sind "+ z.ToString() +" Felder im Grid";*/
        }

        private void Nord_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
