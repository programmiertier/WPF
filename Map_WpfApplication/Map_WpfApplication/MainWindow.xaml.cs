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
using static System.Math;


namespace Map_WpfApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Point> koord = new List<Point>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse markierung = new Ellipse
            {
                Width = 10,
                Height = 10,
                Fill = Brushes.Purple,
                Margin = new Thickness(e.GetPosition(Application.Current.MainWindow).X,
                                        e.GetPosition(Application.Current.MainWindow).Y, 0, 0),
            };
            diekarte.Children.Add(markierung);
            koord.Add(e.GetPosition(Application.Current.MainWindow));
            // MessageBox.Show(e.GetPosition(Application.Current.MainWindow).ToString());
            koord.Add(e.GetPosition(Application.Current.MainWindow));
            if (koord.Count == 2)
            {
                double entfernung;
                entfernung = Math.Sqrt(Math.Pow(Math.Abs(koord[0].X - koord[1].X), 2) 
                                     + Math.Pow(Math.Abs(koord[0].Y - koord[1].Y), 2));
                MessageBox.Show(entfernung.ToString());
            }
        }
    }
}
