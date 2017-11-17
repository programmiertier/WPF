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

namespace MoreClasse_WpfApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for (int zaehl = 0; zaehl < 64; zaehl++)
            {
                Label label = new Label();
                uniformiert.Children.Add(label);        // call by reference, deswegen egal, wo es steht
                label.Name = "label" + zaehl;
                // label.Content = label.Name;             // bei einmaliger Vergabe, ist es vom Speicher egal, aber wenn ich zehnmal "label" +zaehl vergeben möchte, ist das hier label.Content = label.Name
                label.MouseDown += label_MouseDown;

                Binding angepasst = new Binding("Name");      // Das war jetzt eher Mist... hat aber lang gedauert. Sehr schön
                angepasst.Source = label;
                label.SetBinding(Label.ContentProperty, angepasst);
            }
        }
        private void label_MouseDown(object sender, MouseButtonEventArgs e)     // RoutedEventArgs statt MouseButtonEventArgs geht auch
        {
            MessageBox.Show("geklickt");
            // MessageBox.Show(((Label)sender).Content.ToString());
        }
    }
}
