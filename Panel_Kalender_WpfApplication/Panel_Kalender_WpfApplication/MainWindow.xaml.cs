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

namespace Panel_Kalender_WpfApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Label headline = new Label
            {
                Content = "April"
            };

            kalender.Children.Add(headline);
            ColumnDefinition cd_april = new ColumnDefinition();
            cd_april.Width = new GridLength(10);
            ColumnDefinition cd_mai = new ColumnDefinition();
            cd_mai.Width = new GridLength(15);
            ColumnDefinition cd_jun = new ColumnDefinition();
            cd_jun.Width = new GridLength(20);
            AprilTage.ColumnDefinitions.Add(cd_april);
            MaiTage.ColumnDefinitions.Add(cd_mai);
            JunTage.ColumnDefintions.Add(cd_jun);
            for (int zaehl = 1; zaehl <= 30; zaehl++)
            {
                Label tag = new Label();
                Grid.SetColumn(tag, zaehl % 7);
                Grid.SetRow(tag, (int)zaehl / 7);
                tag.Content = zaehl;
                AprilTage.Children.Add(tag);
            }
        }
    }
}
