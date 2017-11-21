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

namespace Fuellstand_WpfApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*for (int zaehl = 1; zaehl < 7; zaehl++)
            {
                Pegel.Children.Add(new Button
                {
                    Content = zaehl,
                    Background = Brushes.Plum,
                    // VerticalAlignment = VerticalAlignment.Bottom,
                    
                });
            } */
            Pegel.Children.Add(new Button
            {
                Content = 6,
                Background = Brushes.Plum,
                VerticalAlignment = VerticalAlignment.Bottom,
            });
        }
    }
}
