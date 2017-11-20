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

namespace StackPanel_Regale_WpfApplication
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
                Content = "Verkaufsraum",
                HorizontalAlignment = HorizontalAlignment.Center,
                Background = Brushes.Azure
            };
            regale.Children.Add(headline);
            for (int zaehl = 0; zaehl < 10; zaehl++)
            {

                StackPanel gang = new StackPanel();
                gang.Name = "Gang" + zaehl;
                gang.Orientation = System.Windows.Controls.Orientation.Horizontal;

                StackPanel gangVor = new StackPanel();
                Label leerVorO = new Label { Content = " " }; leerVorO.Background = Brushes.AntiqueWhite;
                Label leerVorM = new Label { Content = " " }; leerVorM.Background = Brushes.AntiqueWhite;
                Label leerVorU = new Label { Content = " " }; leerVorU.Background = Brushes.AntiqueWhite;
                gangVor.Children.Add(leerVorO);
                gangVor.Children.Add(leerVorM);
                gangVor.Children.Add(leerVorU);
                for (int reg = 0; reg < 40; reg++)
                {
                    StackPanel regganreg = new StackPanel();
                    regganreg.Orientation = System.Windows.Controls.Orientation.Vertical;
                    Label regal_re = new Label { Content = "R" + ((zaehl * 40 + reg) * 2).ToString("D3") };
                    Label leer = new Label { Content = " " }; leer.Background = Brushes.AntiqueWhite;
                    Label regal_r = new Label { Content = "R" + (((zaehl * 40 + reg) * 2) + 1).ToString("D3") };

                    regganreg.Children.Add(regal_re);
                    regganreg.Children.Add(leer);
                    regganreg.Children.Add(regal_r);

                    gang.Children.Add(regganreg);
                }
                StackPanel gangNach = new StackPanel();
                gangNach.Orientation = System.Windows.Controls.Orientation.Vertical;

                Label leerNachO = new Label { Content = " " }; leerVorO.Background = Brushes.AntiqueWhite;
                Label leerNachM = new Label { Content = " " }; leerVorM.Background = Brushes.AntiqueWhite;
                Label leerNachU = new Label { Content = " " }; leerVorU.Background = Brushes.AntiqueWhite;
                gangNach.Children.Add(leerNachO);
                gangNach.Children.Add(leerNachM);
                gangNach.Children.Add(leerNachU);
                gang.Children.Add(gangNach);
                regale.Children.Add(gang);
            }
        }
    }
}
