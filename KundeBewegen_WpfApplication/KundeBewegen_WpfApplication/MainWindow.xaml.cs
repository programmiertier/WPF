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
        private AnimationClock _taktgeberHinab = null;
        private AnimationClock _taktgeberQuer = null;
        public static double raumlaenge = 400;
        public static double raumbreite = 600;
        public static bool nochnichtbesucht = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bewegung_Click(object sender, RoutedEventArgs e)
        {   // der Start der Bewegung soll auf Click erfolgen

            // Bewegungsparameter festlegen
            DoubleAnimation kundeBewegung = new DoubleAnimation
            {
                // From = 0,
                To = raumlaenge,
                By = 100,
                Duration = TimeSpan.Parse("0:0:10")
            };
            DoubleAnimation kundeBewegungQuer = new DoubleAnimation
            {
                From = 0,
                To = raumbreite,
                // AutoReverse = true,
                Duration = TimeSpan.Parse("0:0:10")
            };
            _taktgeberHinab = kundeBewegung.CreateClock();
            _taktgeberQuer = kundeBewegungQuer.CreateClock();
            kunde.ApplyAnimationClock(Canvas.TopProperty, _taktgeberHinab);
            kunde.ApplyAnimationClock(Canvas.LeftProperty, _taktgeberQuer);
            _taktgeberQuer.Controller.Pause();
            // links Event          // rechts der Delegat (adresszeiger)
            _taktgeberHinab.Completed += taktgeberCompleted; // event, der am Ende
            _taktgeberHinab.CurrentTimeInvalidated += taktgeberHinabtickt;
            EventHandler weiterrunter = (s, platzhalter) => _taktgeberHinab.Controller.Resume();
            _taktgeberQuer.Completed += weiterrunter;
        }

        private void taktgeberCompleted(object sender, EventArgs e)     // nicht routed!    // animationclocks haben nur events, keine routed
        {
            bewegung.Content = "angekommen";
        }

        private void taktgeberHinabtickt(object sender, EventArgs e)
        {
            nochnichtbesucht = true;
            bewegung.Content = kunde.GetValue(Canvas.TopProperty);  // _taktgeber.CurrentTime.ToString();
            double aktuellePosition;
            Double.TryParse((kunde.GetValue(Canvas.TopProperty).ToString()), out aktuellePosition);

            double gang1Pos;
            Double.TryParse((gang1.GetValue(Canvas.TopProperty).ToString()), out gang1Pos);
            if (aktuellePosition > gang1Pos)
            {
                bewegung.Content = "hier abbiegen";
                _taktgeberHinab.Controller.Pause();
                _taktgeberQuer.Controller.Resume();
                nochnichtbesucht = !nochnichtbesucht;
                
            }
        }

        private void pausieren(object sender, RoutedEventArgs e)
        {
            _taktgeberHinab.Controller.Pause();
        }

        private void weiter(object sender, RoutedEventArgs e)
        {
            _taktgeberHinab.Controller.Resume();
        }

        private void reset(object sender, RoutedEventArgs e)
        {
            _taktgeberHinab.Controller.Begin();
        }

        private void beenden(object sender, RoutedEventArgs e)
        {
            _taktgeberHinab.Controller.SkipToFill();
        }

        private void liste_Click(object sender, RoutedEventArgs e)
        {
            _taktgeberHinab.Controller.Pause();
            MessageBox.Show("Anzeige der Einkaufsliste");
            _taktgeberHinab.Controller.Resume();
        }

        private void kunde_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _taktgeberHinab.Controller.Pause();
            MessageBox.Show("Anzeige der Einkaufsliste");
            _taktgeberHinab.Controller.Resume();
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            speedration.Content = e.NewValue;
            if (_taktgeberHinab != null)
            {
                var bindung = new Binding();
                bindung.Source = _taktgeberHinab.Controller;
                bindung.Path = new PropertyPath("SpeedRatio");
                slider.SetBinding(Slider.ValueProperty, bindung);
            }
        }
    }
}
