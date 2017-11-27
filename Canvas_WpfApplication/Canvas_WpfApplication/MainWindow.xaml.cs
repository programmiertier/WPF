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
        public MainWindow()
        {
            InitializeComponent();
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
    }
}
