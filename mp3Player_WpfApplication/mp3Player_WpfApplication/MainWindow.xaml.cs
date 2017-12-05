using Microsoft.Win32;
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

namespace mp3Player_WpfApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // private MediaPlayer mediaPlayer = new MediaPlayer();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpenAudioFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\Users\\Zimmermann\\Documents\\C#\\WPF\\mp3Player_WpfApplication\\mp3Player_WpfApplication";
            openFileDialog.Filter = "MP files (*.mp*)|*.mp*|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
                mediaPlayer.Source = new Uri(openFileDialog.FileName);
                mediaPlayer.LoadedBehavior = MediaState.Manual;
            }
        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            MessageBox.Show("Lied ist vorbei");
        }

        private void playBtn_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }

        private void pauseBtn_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }
        private void stopBtn_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void weiBtn_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }
    }
}
