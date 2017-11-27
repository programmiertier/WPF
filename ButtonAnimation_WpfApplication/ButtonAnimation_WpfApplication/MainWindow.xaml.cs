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
            DoubleAnimation veraenderung                          = new DoubleAnimation();

            // ausgehend vom Startwert, wenn dieser beim Start geändert werden soll
            veraenderung.From = 50;   // cs überschreibt xaml
            // ändert den Zielwert
            veraenderung.To = 300;
            // in welcher Zeit soll die Änderung erfolgen
            veraenderung.Duration = TimeSpan.Parse("0:0:3");
            // optional kann man es natürlich auch wieder rückgängig machen
            veraenderung.AutoReverse = true;
            // und wiederholen kann man das auch lassen
            veraenderung.RepeatBehavior = RepeatBehavior.Forever;
            // wer soll animiert werden
            btn01.BeginAnimation(Button.WidthProperty, veraenderung);
            btn01.BeginAnimation(Button.HeightProperty, veraenderung);

            
            // MessageBox.Show(sender.ToString() + e.ToString());       // hat funktioniert, also weiter
        }
    }
}
