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

namespace ButtonZaehl_WpfApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Label zahlhier = new Label();
        public MainWindow()
        {
            InitializeComponent();
            hierdasProgramm.AddChild(gritty());
        }
        public static Grid gritty()
        {
            Button hoch = new Button();
            hoch.Name = "herauf";
            hoch.Content = hoch.Name;
            hoch.Click += new RoutedEventHandler(hoch_Click);

            Button runter = new Button();
            runter.Name = "herab";
            runter.Content = runter.Name;
            runter.Click += new RoutedEventHandler(runter_Click);


            zahlhier.Name = "Volumen";
            zahlhier.Content = "0";
            zahlhier.FontSize = 36;
            zahlhier.VerticalAlignment = VerticalAlignment.Center;
            zahlhier.HorizontalAlignment = HorizontalAlignment.Center;

            Grid grittygrid = new Grid();
            grittygrid.ShowGridLines = false;

            RowDefinition row1 = new RowDefinition();
            RowDefinition row2 = new RowDefinition();
            grittygrid.RowDefinitions.Add(row1);
            grittygrid.RowDefinitions.Add(row2);
            

            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            grittygrid.ColumnDefinitions.Add(col1);
            grittygrid.ColumnDefinitions.Add(col2);

            Grid.SetRow(hoch, 0);
            Grid.SetRow(runter, 1);
            //Grid.SetRow(zahlhier, 0);
            Grid.SetRowSpan(zahlhier, 2);
            Grid.SetColumn(hoch, 1);
            Grid.SetColumn(runter, 1);
            Grid.SetColumn(zahlhier, 0);

            grittygrid.Children.Add(hoch);
            grittygrid.Children.Add(runter);
            grittygrid.Children.Add(zahlhier);

            return grittygrid;
        }

        private static void hoch_Click(object sender, RoutedEventArgs re)
        {
            zahlhier.Content = Convert.ToInt32(zahlhier.Content.ToString()) + 1;
        }

        private static void runter_Click(object sender, RoutedEventArgs re)
        {
            zahlhier.Content = Convert.ToInt32(zahlhier.Content.ToString()) - 1;
        }
    }
}
