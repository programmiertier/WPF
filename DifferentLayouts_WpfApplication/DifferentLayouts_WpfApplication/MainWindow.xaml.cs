using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DifferentLayouts_WpfApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Label gruss = new Label();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void anfang_Click(object sender, RoutedEventArgs e)
        {
            dockhier.LastChildFill = true;
            gruss.Content = "hi na";
            gruss.VerticalContentAlignment = VerticalAlignment.Center;
            gruss.HorizontalContentAlignment = HorizontalAlignment.Center;
            gruss.FontSize = 30;
            dockhier.Children.Add(gruss);
        }

        private void mitte_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ende_Click(object sender, RoutedEventArgs e)
        {
            // dockhier.LastChildFill = false;
            dockhier.Children.Remove(gruss);
            UniformGrid raster = new UniformGrid();
            for (int zaehl = 0; zaehl < 16; zaehl++)
            {
                Label l = new Label { Content = zaehl };
                raster.Children.Add(l);
            }
            dockhier.Children.Add(raster);
        }


    }
}
