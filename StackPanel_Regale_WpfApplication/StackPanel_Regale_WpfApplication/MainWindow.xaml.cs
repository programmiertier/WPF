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

namespace StackPanel_Regale_WpfApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Label> gangbei = new List<Label>(); // soll das Abbiegen in die Gänge steuern
        
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
                gangVor.Orientation = System.Windows.Controls.Orientation.Vertical;
                Label leerVorO = new Label { Content = " " }; leerVorO.Background = Brushes.AntiqueWhite;
                Label leerVorM = new Label { Content = " " }; leerVorM.Background = Brushes.AntiqueWhite;
                gangbei.Add(leerVorM);
                Label leerVorU = new Label { Content = " " }; leerVorU.Background = Brushes.AntiqueWhite;
                gangVor.Children.Add(leerVorO);
                gangVor.Children.Add(leerVorM);
                gangVor.Children.Add(leerVorU);
                gang.Children.Add(gangVor);
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // double pos;
            foreach (Label g in gangbei)
            {
                Point relativePoint = g.TransformToAncestor(Application.Current.MainWindow).Transform(new Point(0, 0));
                MessageBox.Show(relativePoint.ToString());
                Ellipse kundenAlsKreis = new Ellipse
                {
                    Width = 10,
                    Height = 10,
                    Fill = Brushes.Black

                };
                canvas.Children.Add(kundenAlsKreis);
                Canvas.SetTop(kundenAlsKreis, relativePoint.Y);
                Canvas.SetLeft(kundenAlsKreis, relativePoint.X);
                
            }
        }
        private void start_Click(object sender, RoutedEventArgs e)
        {
            Point relativePoint = gangbei[0].TransformToAncestor(Application.Current.MainWindow).Transform(new Point(0, 0));

            DoubleAnimation x = new DoubleAnimation();
            DoubleAnimation y = new DoubleAnimation();
            x.From = 40;
            x.To = relativePoint.X;
            y.To = relativePoint.Y;
            x.Duration = TimeSpan.Parse("0:0:2");
            y.Duration = TimeSpan.Parse("0:0:2");
            kunde.BeginAnimation(Canvas.TopProperty, y);
            kunde.BeginAnimation(Canvas.LeftProperty, x);
        }
    }
}
