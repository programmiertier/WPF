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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EigeneKlasseIn_WpfApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int anzKunden;
        public MainWindow()
        {
            InitializeComponent();
            Kunde.kundennummer = 1;

            // kann man Kunde einfügen, aber dann ist kein fertiges Fenster gezeichnet
            // Kunde heinz = new Kunde();
            
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /* Kunde heinz = new Kunde();
            raumdarstellung.Children.Add(new Image() { Source = heinz.wagen.Source });
            // Canvas.SetLeft(raumdarstellung.Children[raumdarstellung.Children.Count-1], 30);
            Kunde meier = new Kunde();
            raumdarstellung.Children.Add(new Image() { Source = meier.wagen.Source });
            // Canvas.SetLeft(raumdarstellung.Children[raumdarstellung.Children.Count - 1], 60);
            Kunde schulz = new Kunde();
            raumdarstellung.Children.Add(new Image() { Source = schulz.wagen.Source });
            // Canvas.SetLeft(raumdarstellung.Children[raumdarstellung.Children.Count - 1], 90);
            Kunde schmidt = new Kunde();
            raumdarstellung.Children.Add(new Image() { Source = schmidt.wagen.Source });
            // Canvas.SetLeft(raumdarstellung.Children[raumdarstellung.Children.Count - 1], 120); */
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            anzKunden = Int32.Parse(slider.Value.ToString());
            bool autoreverse = true;
            

            ThicknessAnimation x = new ThicknessAnimation();
            Thickness bla = new Thickness();
            bla.Left = 400;
            
            // bla.Top = n.wagen.Margin.Top;
            
            x.Duration = TimeSpan.Parse("0:0:3");
            x.BeginTime = TimeSpan.Parse("0:0:" + Kunde.kundennummer);
            for (int zaehl = 0; zaehl < anzKunden; zaehl++)
            {
                Kunde n = new Kunde();
                n.wagen.MouseDown += Wagen_MouseDown;
                n.wagen.Margin = new Thickness(20 * Kunde.kundennummer, 30 * Kunde.kundennummer, 0, 0);
                raumdarstellung.Children.Add(n.wagen);

                bla.Top = n.wagen.Margin.Top;
                x.To = bla;
                x.AutoReverse = autoreverse;
                n.wagen.BeginAnimation(Image.MarginProperty, x);
                autoreverse = !autoreverse;

            }

        }
        private void Wagen_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }
    }
}
