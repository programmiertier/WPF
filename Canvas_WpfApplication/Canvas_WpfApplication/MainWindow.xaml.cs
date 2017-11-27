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

namespace Canvas_WpfApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double strecke;
        public static int durchlauf;
        public MainWindow()
        {
            InitializeComponent();
            strecke = 475;
            durchlauf = 1;
        }
        private void start_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation move = new DoubleAnimation();
            move.From = 10;
            move.To = 500;
            move.Duration = TimeSpan.Parse("0:0:10");
            // move = move.CreateClock();
            // kunde.ApplyAnimationClock(Canvas.TopProperty, move);

            DoubleAnimation groesser = new DoubleAnimation
            {
                From = 100,
                To = 500,
                Duration = TimeSpan.Parse("0:0:10")
            };
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation untenbewegung = new DoubleAnimation
            {

                From = 0,
                To = 475,
                // AutoReverse = true,
                // RepeatBehavior = RepeatBehavior.Forever,
                Duration = TimeSpan.Parse("0:0:3")
            };

            DoubleAnimation querBewegung = new DoubleAnimation
            {
                From = -25,
                To = 800,
                Duration = TimeSpan.Parse("0:0:30")
            };
            untenbewegung.Completed += RunterRollen_Completed;
            elli.BeginAnimation(Canvas.TopProperty, untenbewegung);
            elli.BeginAnimation(Canvas.LeftProperty, querBewegung);
            
        }

        private void RunterRollen_Completed(object sender, EventArgs e)
        {
            durchlauf++;
            strecke = strecke * 0.5;
            DoubleAnimation bewegen = new DoubleAnimation
            {
                To = 475 - strecke,
                Duration = TimeSpan.Parse("0:0:3"),
                AutoReverse = true
            };
            if (durchlauf < 5)
            { bewegen.Completed += RunterRollen_Completed; }
            else
            {   bewegen.Completed -= RunterRollen_Completed;
                bewegen.Completed += ende; }
            
            elli.BeginAnimation(Canvas.TopProperty, bewegen);
            
            // MessageBox.Show("ist beendet");
        }
        private void ende(object sender, EventArgs e)
        {
            MessageBox.Show("ja is vorbei");
        }
    }
}
