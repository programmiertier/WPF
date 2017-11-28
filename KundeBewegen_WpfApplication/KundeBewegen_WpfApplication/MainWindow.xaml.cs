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

namespace KundeBewegen_WpfApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AnimationClock _taktgeber = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bewegung_Click(object sender, RoutedEventArgs e)
        {   // der Start der Bewegung soll auf Click erfolgen

            // Bewegungsparameter festlegen
            DoubleAnimation kundeBewegung = new DoubleAnimation
            {
                From = 0,
                To = 400,
                Duration = TimeSpan.Parse("0:0:3")
            };
            _taktgeber = kundeBewegung.CreateClock();
            kunde.ApplyAnimationClock(Canvas.TopProperty, _taktgeber);
            // links Event          // rechts der Delegat (adresszeiger)
            _taktgeber.Completed += taktgeberCompleted; // event, der am Ende
            _taktgeber.CurrentTimeInvalidated += taktgeberTickt;
        }

        private void taktgeberCompleted(object sender, EventArgs e)     // nicht routed!    // animationclocks haben nur events, keine routed
        {
            bewegung.Content = "angekommen";
        }

        private void taktgeberTickt(object sender, EventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }
    }
}
