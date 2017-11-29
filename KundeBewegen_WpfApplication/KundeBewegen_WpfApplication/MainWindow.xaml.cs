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
        double gangErreicht; // = 80.0;
        double kundehoehe;
        double gangHoehe;
        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show(erstesRegal.ActualHeight.ToString());
            for (int zaehl = 0; zaehl < 20; zaehl++)
            {
                Regal.Children.Add(new Label
                {
                    Content = zaehl,
                    Background = Brushes.Green,
                    BorderThickness = new Thickness(1),
                    BorderBrush = Brushes.Black,
                    Width = 30
                });
            }
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
            Double.TryParse((erstesRegal.GetValue(Canvas.TopProperty).ToString()), out gang1Pos);
            if (aktuellePosition > gangErreicht)
            {
                bewegung.Content = "hier abbiegen";
                _taktgeberHinab.Controller.Pause();
                quer(sender, e);
                gangErreicht += (gangErreicht + gangHoehe);
                MessageBox.Show("Nächstes Abbiegen bei: " + gangErreicht);
            }
        }

        private void quer(object sender, EventArgs e)
        {
            DoubleAnimation gang = new DoubleAnimation
            {
                From = 0,
                To = 750,
                Duration = TimeSpan.Parse("0:0:5"),
                AutoReverse = true
            };
            gang.Completed += Gang_Completed;
            kunde.BeginAnimation(Canvas.LeftProperty, gang);
        }

        private void Gang_Completed(object sender, EventArgs e)
        {
            _taktgeberHinab.Controller.Resume();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gangErreicht = erstesRegal.ActualHeight;
            kundehoehe = kunde.ActualHeight;
            double top;
            double bottom;
            Double.TryParse(erstesRegal.GetValue(Canvas.BottomProperty).ToString(), out bottom);
            Double.TryParse(zweitesRegal.GetValue(Canvas.TopProperty).ToString(), out top);
            MessageBox.Show(bottom.ToString() + " " + top.ToString());
            gangHoehe = top - gangErreicht;
        }
    }
}
