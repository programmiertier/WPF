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

namespace Jukebox_WpfApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaTimeline _timeline;
        private MediaClock _clock;
        public static string pfad = "C:\\Users\\Zimmermann\\Documents\\C#\\WPF\\Jukebox_WpfApplication\\Jukebox_WpfApplication\\mp\\";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void clickyClick(object sender, RoutedEventArgs e)
        {
            var gewaehlt = sender as RadioButton;
            // MessageBox.Show(gewaehlt.Content.ToString() + "angeklickt" );
            MessageBox.Show(pfad + gewaehlt.Tag.ToString());

            /* auswahlhier.Content = "Ihre Auswahl ist:\n" + Content;
            if (gewaehlt.IsChecked == true)
                {
                    auswahlhier.Content += "\n" + gewaehlt.Tag.ToString();
                }   */
            string datei = gewaehlt.Tag.ToString();
            Uri pfaad = new Uri(pfad + datei);
            // Uri pfad = new Uri("C:\\Users\\XX\\Documents\\C#\\WPF\\Jukebox_WpfApplication\\Jukebox_WpfApplication\\mp\\" + datei);

            _timeline = new MediaTimeline();
            _timeline.Source = pfaad;
            _clock = _timeline.CreateClock();
            _clock.CurrentTimeInvalidated += _clock_CurrentTimeInvalidated;
            _clock.Controller.Stop();
            MediaPlayer player = new MediaPlayer();
            player.MediaOpened += player_MediaOpened;
            player.Clock = _clock;
            
        }

        private void player_MediaOpened(object sender, EventArgs e)
        {
            MediaPlayer temp = sender as MediaPlayer;
            progressbar.Maximum = temp.NaturalDuration.TimeSpan.Ticks;
            startbtn.Opacity = 1;
        }

        private void _clock_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            laufzeit.Text = _clock.CurrentTime.ToString();
            progressbar.Value = _clock.CurrentTime.Value.Ticks;
        }

        private void abspielen_Click(object sender, RoutedEventArgs e)
        {
            _clock.Controller.Begin();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
