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

namespace ImageShow_WpfApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private String[] IMAGES = { "01.png", "02.png", "03.png", "04.png", "05.png", "06.png", "07.png", "08.png"};
        private String pfad = "C:\\Users\\kaffeetier\\Documents\\c#\\WPF\\ImageShow_WpfApplication\\ImageShow_WpfApplication\\";
        private double nr = 0;
        private double z = 1;
        public MainWindow()
        {
            InitializeComponent();
            foreach (var name in IMAGES)
            {
                Image bild = new Image();
                bild.Source = new BitmapImage(new Uri(pfad+name));
                bild.Width = 100;
                bild.Height = 100;
                
                bild.Margin = new Thickness((nr+z++ % 2) * schirm.Width / 4, (nr % 2) * schirm.Height / 4, 0, 0);
                nr++;
                schirm.Children.Add(bild);
            }
            
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            ThicknessAnimation rotate = new ThicknessAnimation();
            Thickness drehung = new Thickness();
            
            drehung.Top = +160;
            rotate.By = drehung;
            rotate.Duration = TimeSpan.Parse("0:0:5");
            schirm.Children[0].BeginAnimation(Image.MarginProperty, rotate);

            drehung.Top = 0;
            drehung.Left = +320;
            rotate.By = drehung;
            schirm.Children[1].BeginAnimation(Image.MarginProperty, rotate);

            drehung.Top = 0;
            drehung.Left = -160;
            rotate.By = drehung;
            schirm.Children[2].BeginAnimation(Image.MarginProperty, rotate);

            drehung.Top = 0;
            drehung.Left = +160;
            rotate.By = drehung;
            schirm.Children[3].BeginAnimation(Image.MarginProperty, rotate);

        }

        private void knopf_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
