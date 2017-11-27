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
using System.Windows.Media.Animation;   // speziell für Animationen
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ButtonAnimation_WpfApplication
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

        public void Winodw_Loaded(object sender, RoutedEventArgs e) // sobald der Schirm einmal komplett geladen ist
        {
            // from, to or by
            // <type>Animation
            DoubleAnimation mehrBreite                          = new DoubleAnimation();

            // ausgehend vom Startwert, wenn dieser beim Start geändert werden soll
            
            // ändert den Zielwert
            mehrBreite.To = 300;
            // in welcher Zeit soll die Änderung erfolgen
            mehrBreite.Duration = TimeSpan.Parse("0:0:3");
            // wer soll animiert werden
            btn01.BeginAnimation(Button.WidthProperty, mehrBreite);
            // MessageBox.Show(sender.ToString() + e.ToString());       // hat funktioniert, also weiter
        }
    }
}
