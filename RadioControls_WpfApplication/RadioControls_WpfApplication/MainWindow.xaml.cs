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

namespace RadioControls_WpfApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<string> berufeliste = new List<string>
        {
            "Pixelschubse", "Kabelfummler", "Oida", "Kabelempfehler"
        };
        public MainWindow()
        {
            InitializeComponent();
            RadioButton sinnlos = new RadioButton();
            sinnlos.Content = "total sinnlos";
            umschueler.Children.Add(sinnlos);

            foreach(string item in berufeliste)
            {
                RadioButton futzi = new RadioButton { Content = item, Name = item };
                
                umschueler.Children.Add(futzi);
            }
        }

        private void maenlClick(object sender, RoutedEventArgs e)
        {
            auswahlhier.Content = "Ihre Auswahl ist:\n" + maenlRadioButton.Content;
            foreach (RadioButton futzi in umschueler.Children)
            {
                if (futzi.IsChecked == true)
                {
                    auswahlhier.Content += "\n" + futzi.Content.ToString();
                }
            }
        }

        private void weiblClick(object sender, RoutedEventArgs e)
        {
            auswahlhier.Content = "Ihre Auswahl ist:\n" + weiblRadioButton.Content;
            foreach (RadioButton futzi in umschueler.Children)
            {
                if (futzi.IsChecked == true)
                {
                    auswahlhier.Content += "\n" + futzi.Content.ToString();
                }
            }
        }
    }
}
